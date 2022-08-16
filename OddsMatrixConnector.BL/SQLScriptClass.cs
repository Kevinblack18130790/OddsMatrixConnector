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

        public static string GetMethod()
        {
            StringBuilder values = new StringBuilder();
            values.AppendLine(CreateMethod<BettingOffer>());
            values.AppendLine(CreateMethod<BettingOfferStatus>());
            values.AppendLine(CreateMethod<BettingType>());
            values.AppendLine(CreateMethod<BettingTypeUsage>());
            values.AppendLine(CreateMethod<Currency>());
            values.AppendLine(CreateMethod<EntityProperty>());
            values.AppendLine(CreateMethod<EntityPropertyType>());
            values.AppendLine(CreateMethod<EntityPropertyValue>());
            values.AppendLine(CreateMethod<EntityType>());
            values.AppendLine(CreateMethod<Event>());
            values.AppendLine(CreateMethod<EventAction>());
            values.AppendLine(CreateMethod<EventActionDetail>());
            values.AppendLine(CreateMethod<EventActionDetailStatus>());
            values.AppendLine(CreateMethod<EventActionDetailType>());
            values.AppendLine(CreateMethod<EventActionDetailTypeUsage>());
            values.AppendLine(CreateMethod<EventActionStatus>());
            values.AppendLine(CreateMethod<EventActionType>());
            values.AppendLine(CreateMethod<EventActionTypeUsage>());
            values.AppendLine(CreateMethod<EventCategory>());
            values.AppendLine(CreateMethod<EventInfo>());
            values.AppendLine(CreateMethod<EventInfoStatus>());
            values.AppendLine(CreateMethod<EventInfoType>());
            values.AppendLine(CreateMethod<EventInfoTypeUsage>());
            values.AppendLine(CreateMethod<EventPart>());
            values.AppendLine(CreateMethod<EventPartDefaultUsage>());
            values.AppendLine(CreateMethod<EventParticipantInfo>());
            values.AppendLine(CreateMethod<EventParticipantInfoDetail>());
            values.AppendLine(CreateMethod<EventParticipantInfoDetailStatus>());
            values.AppendLine(CreateMethod<EventParticipantInfoDetailType>());
            values.AppendLine(CreateMethod<EventParticipantInfoDetailTypeUsage>());
            values.AppendLine(CreateMethod<EventParticipantInfoStatus>());
            values.AppendLine(CreateMethod<EventParticipantInfoType>());
            values.AppendLine(CreateMethod<EventParticipantInfoTypeUsage>());
            values.AppendLine(CreateMethod<EventParticipantRelation>());
            values.AppendLine(CreateMethod<EventParticipantRestriction>());
            values.AppendLine(CreateMethod<EventStatus>());
            values.AppendLine(CreateMethod<EventTemplate>());
            values.AppendLine(CreateMethod<EventType>());
            values.AppendLine(CreateMethod<EventTypeUsage>());
            values.AppendLine(CreateMethod<Language>());
            values.AppendLine(CreateMethod<Location>());
            values.AppendLine(CreateMethod<LocationRelation>());
            values.AppendLine(CreateMethod<LocationRelationType>());
            values.AppendLine(CreateMethod<LocationType>());
            values.AppendLine(CreateMethod<Market>());
            values.AppendLine(CreateMethod<MarketOutcomeRelation>());
            values.AppendLine(CreateMethod<Outcome>());
            values.AppendLine(CreateMethod<OutcomeParticipantRelation>());
            values.AppendLine(CreateMethod<OutcomeStatus>());
            values.AppendLine(CreateMethod<OutcomeType>());
            values.AppendLine(CreateMethod<OutcomeTypeBettingTypeRelation>());
            values.AppendLine(CreateMethod<OutcomeTypeUsage>());
            values.AppendLine(CreateMethod<Participant>());
            values.AppendLine(CreateMethod<ParticipantRelation>());
            values.AppendLine(CreateMethod<ParticipantRelationType>());
            values.AppendLine(CreateMethod<ParticipantRole>());
            values.AppendLine(CreateMethod<ParticipantType>());
            values.AppendLine(CreateMethod<ParticipantTypeRoleUsage>());
            values.AppendLine(CreateMethod<ParticipantUsage>());
            values.AppendLine(CreateMethod<Provider>());
            values.AppendLine(CreateMethod<ProviderEntityMapping>());
            values.AppendLine(CreateMethod<ProviderEventRelation>());
            values.AppendLine(CreateMethod<ScoringUnit>());
            values.AppendLine(CreateMethod<Source>());
            values.AppendLine(CreateMethod<Sport>());
            values.AppendLine(CreateMethod<StreamingProvider>());
            values.AppendLine(CreateMethod<StreamingProviderEventRelation>());
            values.AppendLine(CreateMethod<Translation>());
            return values.ToString();
        }

        private static string CreateMethod<T>() where T : class
        {
            Type methodName = typeof(T);
            string method = "";

            //method += $"private static void AddListDB(this List<{methodName.Name}> entities)"+Environment.NewLine;
            //method += "{" + Environment.NewLine;
            //method += $"    try                                                         " + Environment.NewLine;
            //method += "    {" + Environment.NewLine;
            //method += $"        using (var context = new OddMatrixDataDataContext())" + Environment.NewLine;
            //method += "        {" + Environment.NewLine;
            //method += $"            List<{methodName.Name}> currentInfo = context.{methodName.Name}s.ToList();  " + Environment.NewLine;
            //method += $"            context.{methodName.Name}s.DeleteAllOnSubmit(currentInfo);  " + Environment.NewLine;
            //method += $"            context.{methodName.Name}s.InsertAllOnSubmit(entities);  " + Environment.NewLine;
            //method += $"            context.SubmitChanges();" + Environment.NewLine;
            //method += "        }" + Environment.NewLine;
            //method += "    }" + Environment.NewLine;
            //method += $"    catch (Exception ex)                                        " + Environment.NewLine;
            //method += "    {" + Environment.NewLine;
            //method += "        throw new Exception($\""+methodName.Name+":{ex.Message}\");" + Environment.NewLine;
            //method += "    }" + Environment.NewLine;
            //method += "}" + Environment.NewLine;

            //method += $"case \"{methodName.Name}\":" + Environment.NewLine;
            //method += "{" + Environment.NewLine;
            //method += $"  return  JsonConvert.DeserializeObject<List<{methodName.Name}>>(json);" + Environment.NewLine;
            //method += "}";

            //method += $"case \"{methodName.Name}\":" + Environment.NewLine;
            //method += "{" + Environment.NewLine;
            //method += $"list{methodName.Name}.AddRange((IEnumerable<SEPC_BD.{methodName.Name}>)entities);" + Environment.NewLine;
            //method += $"break;" + Environment.NewLine;
            //method += "}";

            //method += $"public static List<{methodName.Name}> TransformEntitiesTo{methodName.Name}(this List<Entity> entities)" + Environment.NewLine;
            //method += "{" + Environment.NewLine;
            //method += "     string json = JsonConvert.SerializeObject(entities);" + Environment.NewLine;
            //method += $"    return JsonConvert.DeserializeObject<List<{methodName.Name}>>(json);" + Environment.NewLine;
            //method += "}" + Environment.NewLine;

            //method += $"list{methodName.Name}.AddListDB();";

            //method += $"case \"{methodName.Name}\":" + Environment.NewLine;
            //method += "{" + Environment.NewLine;
            //method += $"list{methodName.Name}.AddRange(entities.TransformEntitiesTo{methodName.Name}());" + Environment.NewLine;
            //method += $"break;" + Environment.NewLine;
            //method += "}";

            //method += $"            List<{methodName.Name}> currentInfo{methodName.Name} = context.{methodName.Name}s.ToList();  " + Environment.NewLine;
            //method += $"            context.{methodName.Name}s.DeleteAllOnSubmit(currentInfo{methodName.Name});  ";

            //method += $"private static void AddListDB(this List<{methodName.Name}> entities)" + Environment.NewLine;
            //method += "{" + Environment.NewLine;
            //method += $"    try                                                         " + Environment.NewLine;
            //method += "    {" + Environment.NewLine;
            //method += $"        using (var context = new OddMatrixDataDataContext())" + Environment.NewLine;
            //method += "        {" + Environment.NewLine;
            //method += $"            context.{methodName.Name}s.InsertAllOnSubmit(entities);  " + Environment.NewLine;
            //method += $"            context.SubmitChanges();" + Environment.NewLine;
            //method += "        }" + Environment.NewLine;
            //method += "    }" + Environment.NewLine;
            //method += $"    catch (Exception ex)                                        " + Environment.NewLine;
            //method += "    {" + Environment.NewLine;
            //method += "        throw new Exception($\"" + methodName.Name + ":{ex.Message}\");" + Environment.NewLine;
            //method += "    }" + Environment.NewLine;
            //method += "}" + Environment.NewLine;

            //method += $"TRUNCATE TABLE [{methodName.Name}];";

            //method += $"case \"{methodName.Name}\":" + Environment.NewLine;
            //method += "{" + Environment.NewLine;
            //method += $"JsonConvert.DeserializeObject<List<{methodName.Name}>>(json).AddListDB<{methodName.Name}>();" + Environment.NewLine;
            //method += "break;" + Environment.NewLine;
            //method += "}";

            //method += $"list{methodName.Name}.AddListDB<{methodName.Name}>();";

            method += $"List<Entity> list{methodName.Name} = new List<Entity>();";

            return method.Replace("ss.","s.").Replace("ys.","ies.");
        }
    }
}
