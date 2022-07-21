// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sdql.SDQLEntityDeserializer
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using com.oddsmatrix.sepc.connector.sportsmodel;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace com.oddsmatrix.sepc.connector.sdql
{
    public static class SDQLEntityDeserializer
    {
        private static readonly Dictionary<string, XmlSerializer> XmlDeserializers = new Dictionary<string, XmlSerializer>();

        internal static Entity Deserialize(string entityName, XmlReader xmlReader)
        {
            Type entityType = SDQLEntityDeserializer.GetEntityType(entityName);
            var obj = (Entity)(!SDQLEntityDeserializer.XmlDeserializers.ContainsKey(entityName) ? new XmlSerializer(entityType) : SDQLEntityDeserializer.XmlDeserializers[entityName]).Deserialize(xmlReader);
            obj.EntityType = entityType.Name;
            return obj;
        }

        internal static Type GetEntityType(string entityName)
        {
            switch (entityName)
            {
                case "BettingOffer":
                    return typeof(BettingOffer);
                case "BettingOfferStatus":
                    return typeof(BettingOfferStatus);
                case "BettingType":
                    return typeof(BettingType);
                case "BettingTypeUsage":
                    return typeof(BettingTypeUsage);
                case "Currency":
                    return typeof(com.oddsmatrix.sepc.connector.sportsmodel.Currency);
                case "EntityProperty":
                    return typeof(EntityProperty);
                case "EntityPropertyType":
                    return typeof(EntityPropertyType);
                case "EntityPropertyValue":
                    return typeof(EntityPropertyValue);
                case "EntityType":
                    return typeof(com.oddsmatrix.sepc.connector.sportsmodel.EntityType);
                case "Event":
                    return typeof(Event);
                case "EventAction":
                    return typeof(EventAction);
                case "EventActionDetail":
                    return typeof(EventActionDetail);
                case "EventActionDetailStatus":
                    return typeof(EventActionDetailStatus);
                case "EventActionDetailType":
                    return typeof(EventActionDetailType);
                case "EventActionDetailTypeUsage":
                    return typeof(EventActionDetailTypeUsage);
                case "EventActionStatus":
                    return typeof(EventActionStatus);
                case "EventActionType":
                    return typeof(EventActionType);
                case "EventActionTypeUsage":
                    return typeof(EventActionTypeUsage);
                case "EventCategory":
                    return typeof(EventCategory);
                case "EventInfo":
                    return typeof(EventInfo);
                case "EventInfoStatus":
                    return typeof(EventInfoStatus);
                case "EventInfoType":
                    return typeof(EventInfoType);
                case "EventInfoTypeUsage":
                    return typeof(EventInfoTypeUsage);
                case "EventPart":
                    return typeof(EventPart);
                case "EventPartDefaultUsage":
                    return typeof(EventPartDefaultUsage);
                case "EventParticipantInfo":
                    return typeof(EventParticipantInfo);
                case "EventParticipantInfoDetail":
                    return typeof(EventParticipantInfoDetail);
                case "EventParticipantInfoDetailStatus":
                    return typeof(EventParticipantInfoDetailStatus);
                case "EventParticipantInfoDetailType":
                    return typeof(EventParticipantInfoDetailType);
                case "EventParticipantInfoDetailTypeUsage":
                    return typeof(EventParticipantInfoDetailTypeUsage);
                case "EventParticipantInfoStatus":
                    return typeof(EventParticipantInfoStatus);
                case "EventParticipantInfoType":
                    return typeof(EventParticipantInfoType);
                case "EventParticipantInfoTypeUsage":
                    return typeof(EventParticipantInfoTypeUsage);
                case "EventParticipantRelation":
                    return typeof(EventParticipantRelation);
                case "EventParticipantRestriction":
                    return typeof(EventParticipantRestriction);
                case "EventStatus":
                    return typeof(EventStatus);
                case "EventTemplate":
                    return typeof(EventTemplate);
                case "EventType":
                    return typeof(EventType);
                case "EventTypeUsage":
                    return typeof(EventTypeUsage);
                case "Language":
                    return typeof(Language);
                case "Location":
                    return typeof(Location);
                case "LocationRelation":
                    return typeof(LocationRelation);
                case "LocationRelationType":
                    return typeof(LocationRelationType);
                case "LocationType":
                    return typeof(LocationType);
                case "Market":
                    return typeof(Market);
                case "MarketOutcomeRelation":
                    return typeof(MarketOutcomeRelation);
                case "Outcome":
                    return typeof(Outcome);
                case "OutcomeParticipantRelation":
                    return typeof(OutcomeParticipantRelation);
                case "OutcomeStatus":
                    return typeof(OutcomeStatus);
                case "OutcomeType":
                    return typeof(OutcomeType);
                case "OutcomeTypeBettingTypeRelation":
                    return typeof(OutcomeTypeBettingTypeRelation);
                case "OutcomeTypeUsage":
                    return typeof(OutcomeTypeUsage);
                case "Participant":
                    return typeof(Participant);
                case "ParticipantRelation":
                    return typeof(ParticipantRelation);
                case "ParticipantRelationType":
                    return typeof(ParticipantRelationType);
                case "ParticipantRole":
                    return typeof(ParticipantRole);
                case "ParticipantType":
                    return typeof(ParticipantType);
                case "ParticipantTypeRoleUsage":
                    return typeof(ParticipantTypeRoleUsage);
                case "ParticipantUsage":
                    return typeof(ParticipantUsage);
                case "Provider":
                    return typeof(Provider);
                case "ProviderEntityMapping":
                    return typeof(ProviderEntityMapping);
                case "ProviderEventRelation":
                    return typeof(ProviderEventRelation);
                case "ScoringUnit":
                    return typeof(ScoringUnit);
                case "Source":
                    return typeof(Source);
                case "Sport":
                    return typeof(Sport);
                case "StreamingProvider":
                    return typeof(StreamingProvider);
                case "StreamingProviderEventRelation":
                    return typeof(StreamingProviderEventRelation);
                case "Translation":
                    return typeof(Translation);
                default:
                    return (Type)null;
            }
        }
    }
}
