using com.oddsmatrix.sepc.connector.sportsmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EventInfo = com.oddsmatrix.sepc.connector.sportsmodel.EventInfo;

namespace OddsMatrixConnector.BL
{
    public static class SQLScriptClass
    {
        public static string GetTables()
        {
            StringBuilder values = new StringBuilder();
            values.AppendLine(CreateTable<BettingOffer>());
            values.AppendLine(CreateTable<BettingOfferStatus>());
            values.AppendLine(CreateTable<BettingType>());
            values.AppendLine(CreateTable<BettingTypeUsage>());
            values.AppendLine(CreateTable<Currency>());
            values.AppendLine(CreateTable<EntityProperty>());
            values.AppendLine(CreateTable<EntityPropertyType>());
            values.AppendLine(CreateTable<EntityPropertyValue>());
            values.AppendLine(CreateTable<EntityType>());
            values.AppendLine(CreateTable<Event>());
            values.AppendLine(CreateTable<EventAction>());
            values.AppendLine(CreateTable<EventActionDetail>());
            values.AppendLine(CreateTable<EventActionDetailStatus>());
            values.AppendLine(CreateTable<EventActionDetailType>());
            values.AppendLine(CreateTable<EventActionDetailTypeUsage>());
            values.AppendLine(CreateTable<EventActionStatus>());
            values.AppendLine(CreateTable<EventActionType>());
            values.AppendLine(CreateTable<EventActionTypeUsage>());
            values.AppendLine(CreateTable<EventCategory>());
            values.AppendLine(CreateTable<EventInfo>());
            values.AppendLine(CreateTable<EventInfoStatus>());
            values.AppendLine(CreateTable<EventInfoType>());
            values.AppendLine(CreateTable<EventInfoTypeUsage>());
            values.AppendLine(CreateTable<EventPart>());
            values.AppendLine(CreateTable<EventPartDefaultUsage>());
            values.AppendLine(CreateTable<EventParticipantInfo>());
            values.AppendLine(CreateTable<EventParticipantInfoDetail>());
            values.AppendLine(CreateTable<EventParticipantInfoDetailStatus>());
            values.AppendLine(CreateTable<EventParticipantInfoDetailType>());
            values.AppendLine(CreateTable<EventParticipantInfoDetailTypeUsage>());
            values.AppendLine(CreateTable<EventParticipantInfoStatus>());
            values.AppendLine(CreateTable<EventParticipantInfoType>());
            values.AppendLine(CreateTable<EventParticipantInfoTypeUsage>());
            values.AppendLine(CreateTable<EventParticipantRelation>());
            values.AppendLine(CreateTable<EventParticipantRestriction>());
            values.AppendLine(CreateTable<EventStatus>());
            values.AppendLine(CreateTable<EventTemplate>());
            values.AppendLine(CreateTable<EventType>());
            values.AppendLine(CreateTable<EventTypeUsage>());
            values.AppendLine(CreateTable<Language>());
            values.AppendLine(CreateTable<Location>());
            values.AppendLine(CreateTable<LocationRelation>());
            values.AppendLine(CreateTable<LocationRelationType>());
            values.AppendLine(CreateTable<LocationType>());
            values.AppendLine(CreateTable<Market>());
            values.AppendLine(CreateTable<MarketOutcomeRelation>());
            values.AppendLine(CreateTable<Outcome>());
            values.AppendLine(CreateTable<OutcomeParticipantRelation>());
            values.AppendLine(CreateTable<OutcomeStatus>());
            values.AppendLine(CreateTable<OutcomeType>());
            values.AppendLine(CreateTable<OutcomeTypeBettingTypeRelation>());
            values.AppendLine(CreateTable<OutcomeTypeUsage>());
            values.AppendLine(CreateTable<Participant>());
            values.AppendLine(CreateTable<ParticipantRelation>());
            values.AppendLine(CreateTable<ParticipantRelationType>());
            values.AppendLine(CreateTable<ParticipantRole>());
            values.AppendLine(CreateTable<ParticipantType>());
            values.AppendLine(CreateTable<ParticipantTypeRoleUsage>());
            values.AppendLine(CreateTable<ParticipantUsage>());
            values.AppendLine(CreateTable<Provider>());
            values.AppendLine(CreateTable<ProviderEntityMapping>());
            values.AppendLine(CreateTable<ProviderEventRelation>());
            values.AppendLine(CreateTable<ScoringUnit>());
            values.AppendLine(CreateTable<Source>());
            values.AppendLine(CreateTable<Sport>());
            values.AppendLine(CreateTable<StreamingProvider>());
            values.AppendLine(CreateTable<StreamingProviderEventRelation>());
            values.AppendLine(CreateTable<Translation>());
            return values.ToString();
        }

        private static string CreateTable<T>() where T : class
        {
            Type table = typeof(T);
            string tableStructure = $"CREATE TABLE {table.Name} {table.GetProperties().GetColumns()}";
            return tableStructure;
        }

        private static string GetColumns(this PropertyInfo[] properties)
        {
            string table = $"({Environment.NewLine}";
            table += string.Join(",", properties
                .Select(x => $"{x.Name} {GetColumnTypeSQL(x.PropertyType)} {(x.Name.Equals("id") ? " PRIMARY KEY" : "")} {Environment.NewLine}").ToList());
            table += $"){Environment.NewLine}GO{Environment.NewLine}";
            return table;
        }

        private static string GetColumnTypeSQL(Type typeValue, string nullable = "NOT NULL")
        {
            switch (Type.GetTypeCode(typeValue))
            {
                case TypeCode.Boolean: { return $"bit {nullable}"; }
                case TypeCode.Byte: { return $"bynary {nullable}"; }
                case TypeCode.Char: { return $"bit {nullable}"; }
                case TypeCode.DateTime: { return $"datetime {nullable}"; }
                case TypeCode.Decimal: { return $"decimal(18,2) {nullable}"; }
                case TypeCode.Double: { return $"float {nullable}"; }
                case TypeCode.Int16: { return $"smallint {nullable}"; }
                case TypeCode.Int32: { return $"int {nullable}"; }
                case TypeCode.Int64: { return $"bigint {nullable}"; }
                case TypeCode.SByte: { return $"binary {nullable}"; }
                case TypeCode.Single: { return $"real {nullable}"; }
                case TypeCode.String: { return $"varchar(200) {nullable}"; }
                case TypeCode.UInt16: { return $"smallint {nullable}"; }
                case TypeCode.UInt32: { return $"int {nullable}"; }
                case TypeCode.UInt64: { return $"bigint {nullable}"; }
                case TypeCode.Object:
                    {
                        if (typeValue.IsGenericType && typeValue.GetGenericTypeDefinition() == typeof(Nullable<>))
                        {
                            return GetColumnTypeSQL(typeValue.GenericTypeArguments[0].GetTypeInfo(), " NULL");
                        }
                        else
                        {
                            return typeValue.FullName;
                        }
                    }
                default: { return $"varchar(50)"; }
            }
        }
    }
}
