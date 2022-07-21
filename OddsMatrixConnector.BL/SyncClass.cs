using com.oddsmatrix.sepc.connector.sportsmodel;
using System.Collections.Generic;
using System.Linq;

namespace OddsMatrixConnector.BL
{
    public class SyncClass
    {
        private static List<BettingOffer> listBettingOffer = new List<BettingOffer>();
        private static List<BettingOfferStatus> listBettingOfferStatus = new List<BettingOfferStatus>();
        private static List<BettingType> listBettingType = new List<BettingType>();
        private static List<BettingTypeUsage> listBettingTypeUsage = new List<BettingTypeUsage>();
        private static List<Currency> listCurrency = new List<Currency>();
        private static List<EntityProperty> listEntityProperty = new List<EntityProperty>();
        private static List<EntityPropertyType> listEntityPropertyType = new List<EntityPropertyType>();
        private static List<EntityPropertyValue> listEntityPropertyValue = new List<EntityPropertyValue>();
        private static List<EntityType> listEntityType = new List<EntityType>();
        private static List<Event> listEvent = new List<Event>();
        private static List<EventAction> listEventAction = new List<EventAction>();
        private static List<EventActionDetail> listEventActionDetail = new List<EventActionDetail>();
        private static List<EventActionDetailStatus> listEventActionDetailStatus = new List<EventActionDetailStatus>();
        private static List<EventActionDetailType> listEventActionDetailType = new List<EventActionDetailType>();
        private static List<EventActionDetailTypeUsage> listEventActionDetailTypeUsage = new List<EventActionDetailTypeUsage>();
        private static List<EventActionStatus> listEventActionStatus = new List<EventActionStatus>();
        private static List<EventActionType> listEventActionType = new List<EventActionType>();
        private static List<EventActionTypeUsage> listEventActionTypeUsage = new List<EventActionTypeUsage>();
        private static List<EventCategory> listEventCategory = new List<EventCategory>();
        private static List<EventInfo> listEventInfo = new List<EventInfo>();
        private static List<EventInfoStatus> listEventInfoStatus = new List<EventInfoStatus>();
        private static List<EventInfoType> listEventInfoType = new List<EventInfoType>();
        private static List<EventInfoTypeUsage> listEventInfoTypeUsage = new List<EventInfoTypeUsage>();
        private static List<EventPart> listEventPart = new List<EventPart>();
        private static List<EventPartDefaultUsage> listEventPartDefaultUsage = new List<EventPartDefaultUsage>();
        private static List<EventParticipantInfo> listEventParticipantInfo = new List<EventParticipantInfo>();
        private static List<EventParticipantInfoDetail> listEventParticipantInfoDetail = new List<EventParticipantInfoDetail>();
        private static List<EventParticipantInfoDetailStatus> listEventParticipantInfoDetailStatus = new List<EventParticipantInfoDetailStatus>();
        private static List<EventParticipantInfoDetailType> listEventParticipantInfoDetailType = new List<EventParticipantInfoDetailType>();
        private static List<EventParticipantInfoDetailTypeUsage> listEventParticipantInfoDetailTypeUsage = new List<EventParticipantInfoDetailTypeUsage>();
        private static List<EventParticipantInfoStatus> listEventParticipantInfoStatus = new List<EventParticipantInfoStatus>();
        private static List<EventParticipantInfoType> listEventParticipantInfoType = new List<EventParticipantInfoType>();
        private static List<EventParticipantInfoTypeUsage> listEventParticipantInfoTypeUsage = new List<EventParticipantInfoTypeUsage>();
        private static List<EventParticipantRelation> listEventParticipantRelation = new List<EventParticipantRelation>();
        private static List<EventParticipantRestriction> listEventParticipantRestriction = new List<EventParticipantRestriction>();
        private static List<EventStatus> listEventStatus = new List<EventStatus>();
        private static List<EventTemplate> listEventTemplate = new List<EventTemplate>();
        private static List<EventType> listEventType = new List<EventType>();
        private static List<EventTypeUsage> listEventTypeUsage = new List<EventTypeUsage>();
        private static List<Language> listLanguage = new List<Language>();
        private static List<Location> listLocation = new List<Location>();
        private static List<LocationRelation> listLocationRelation = new List<LocationRelation>();
        private static List<LocationRelationType> listLocationRelationType = new List<LocationRelationType>();
        private static List<LocationType> listLocationType = new List<LocationType>();
        private static List<Market> listMarket = new List<Market>();
        private static List<MarketOutcomeRelation> listMarketOutcomeRelation = new List<MarketOutcomeRelation>();
        private static List<Outcome> listOutcome = new List<Outcome>();
        private static List<OutcomeParticipantRelation> listOutcomeParticipantRelation = new List<OutcomeParticipantRelation>();
        private static List<OutcomeStatus> listOutcomeStatus = new List<OutcomeStatus>();
        private static List<OutcomeType> listOutcomeType = new List<OutcomeType>();
        private static List<OutcomeTypeBettingTypeRelation> listOutcomeTypeBettingTypeRelation = new List<OutcomeTypeBettingTypeRelation>();
        private static List<OutcomeTypeUsage> listOutcomeTypeUsage = new List<OutcomeTypeUsage>();
        private static List<Participant> listParticipant = new List<Participant>();
        private static List<ParticipantRelation> listParticipantRelation = new List<ParticipantRelation>();
        private static List<ParticipantRelationType> listParticipantRelationType = new List<ParticipantRelationType>();
        private static List<ParticipantRole> listParticipantRole = new List<ParticipantRole>();
        private static List<ParticipantType> listParticipantType = new List<ParticipantType>();
        private static List<ParticipantTypeRoleUsage> listParticipantTypeRoleUsage = new List<ParticipantTypeRoleUsage>();
        private static List<ParticipantUsage> listParticipantUsage = new List<ParticipantUsage>();
        private static List<Provider> listProvider = new List<Provider>();
        private static List<ProviderEntityMapping> listProviderEntityMapping = new List<ProviderEntityMapping>();
        private static List<ProviderEventRelation> listProviderEventRelation = new List<ProviderEventRelation>();
        private static List<ScoringUnit> listScoringUnit = new List<ScoringUnit>();
        private static List<Source> listSource = new List<Source>();
        private static List<Sport> listSport = new List<Sport>();
        private static List<StreamingProvider> listStreamingProvider = new List<StreamingProvider>();
        private static List<StreamingProviderEventRelation> listStreamingProviderEventRelation = new List<StreamingProviderEventRelation>();
        private static List<Translation> listTranslation = new List<Translation>();

        public static void ProcessChange(EntityChangeBatch change)
        {
            var h = change.EntityChanges
                .Select(x =>
                {
                    switch (x.GetType().Name)
                    {
                        case "EntityCreate":
                            {
                                return ProcessChange((EntityCreate)x);
                            }
                        case "EntityUpdate":
                            {
                                return ProcessChange((EntityUpdate)x);
                            }
                        case "EntityDelete":
                            {
                                return ProcessChange((EntityDelete)x);
                            }
                        default: return null;
                    }
                }).FirstOrDefault();
        }
        private static string ProcessChange(EntityCreate create)
        {

            return "";
        }

        private static string ProcessChange(EntityUpdate update)
        {

            return "";
        }

        private static string ProcessChange(EntityDelete delete)
        {

            return "";
        }

        public decimal GetAmerican(decimal value)
        {
            return value < 2 ? (-100 / (value - 1)) : ((value - 1) * 100);
        }

        public static void GetEntityType(string entityName, Entity entity)
        {
            switch (entityName)
            {
                case "BettingOffer":
                    listBettingOffer.Add((BettingOffer)entity);
                    break;
                case "BettingOfferStatus":
                    listBettingOfferStatus.Add((BettingOfferStatus)entity);// = new List<BettingOfferStatus>();
                    break;
                case "BettingType":
                    listBettingType.Add((BettingType)entity);// = new List<BettingType>();
                    break;
                case "BettingTypeUsage":
                    listBettingTypeUsage.Add((BettingTypeUsage)entity);// = new List<BettingTypeUsage>();
                    break;
                case "Currency":
                    listCurrency.Add((Currency)entity);// = new List<Currency>();
                    break;
                case "EntityProperty":
                    listEntityProperty.Add((EntityProperty)entity);// = new List<EntityProperty>();
                    break;
                case "EntityPropertyType":
                    listEntityPropertyType.Add((EntityPropertyType)entity);// = new List<EntityPropertyType>();
                    break;
                case "EntityPropertyValue":
                    listEntityPropertyValue.Add((EntityPropertyValue)entity);// = new List<EntityPropertyValue>();
                    break;
                case "EntityType":
                    listEntityType.Add((EntityType)entity);// = new List<EntityType>();
                    break;
                case "Event":
                    listEvent.Add((Event)entity);// = new List<Event>();
                    break;
                case "EventAction":
                    listEventAction.Add((EventAction)entity);// = new List<EventAction>();
                    break;
                case "EventActionDetail":
                    listEventActionDetail.Add((EventActionDetail)entity);// = new List<EventActionDetail>();
                    break;
                case "EventActionDetailStatus":
                    listEventActionDetailStatus.Add((EventActionDetailStatus)entity);// = new List<EventActionDetailStatus>();
                    break;
                case "EventActionDetailType":
                    listEventActionDetailType.Add((EventActionDetailType)entity);// = new List<EventActionDetailType>();
                    break;
                case "EventActionDetailTypeUsage":
                    listEventActionDetailTypeUsage.Add((EventActionDetailTypeUsage)entity);// = new List<EventActionDetailTypeUsage>();
                    break;
                case "EventActionStatus":
                    listEventActionStatus.Add((EventActionStatus)entity);// = new List<EventActionStatus>();
                    break;
                case "EventActionType":
                    listEventActionType.Add((EventActionType)entity);// = new List<EventActionType>();
                    break;
                case "EventActionTypeUsage":
                    listEventActionTypeUsage.Add((EventActionTypeUsage)entity);// = new List<EventActionTypeUsage>();
                    break;
                case "EventCategory":
                    listEventCategory.Add((EventCategory)entity);// = new List<EventCategory>();
                    break;
                case "EventInfo":
                    listEventInfo.Add((EventInfo)entity);// = new List<EventInfo>();
                    break;
                case "EventInfoStatus":
                    listEventInfoStatus.Add((EventInfoStatus)entity);// = new List<EventInfoStatus>();
                    break;
                case "EventInfoType":
                    listEventInfoType.Add((EventInfoType)entity);// = new List<EventInfoType>();
                    break;
                case "EventInfoTypeUsage":
                    listEventInfoTypeUsage.Add((EventInfoTypeUsage)entity);// = new List<EventInfoTypeUsage>();
                    break;
                case "EventPart":
                    listEventPart.Add((EventPart)entity);// = new List<EventPart>();
                    break;
                case "EventPartDefaultUsage":
                    listEventPartDefaultUsage.Add((EventPartDefaultUsage)entity);// = new List<EventPartDefaultUsage>();
                    break;
                case "EventParticipantInfo":
                    listEventParticipantInfo.Add((EventParticipantInfo)entity);// = new List<EventParticipantInfo>();
                    break;
                case "EventParticipantInfoDetail":
                    listEventParticipantInfoDetail.Add((EventParticipantInfoDetail)entity);// = new List<EventParticipantInfoDetail>();
                    break;
                case "EventParticipantInfoDetailStatus":
                    listEventParticipantInfoDetailStatus.Add((EventParticipantInfoDetailStatus)entity);// = new List<EventParticipantInfoDetailStatus>();
                    break;
                case "EventParticipantInfoDetailType":
                    listEventParticipantInfoDetailType.Add((EventParticipantInfoDetailType)entity);// = new List<EventParticipantInfoDetailType>();
                    break;
                case "EventParticipantInfoDetailTypeUsage":
                    listEventParticipantInfoDetailTypeUsage.Add((EventParticipantInfoDetailTypeUsage)entity);// = new List<EventParticipantInfoDetailTypeUsage>();
                    break;
                case "EventParticipantInfoStatus":
                    listEventParticipantInfoStatus.Add((EventParticipantInfoStatus)entity);// = new List<EventParticipantInfoStatus>();
                    break;
                case "EventParticipantInfoType":
                    listEventParticipantInfoType.Add((EventParticipantInfoType)entity);// = new List<EventParticipantInfoType>();
                    break;
                case "EventParticipantInfoTypeUsage":
                    listEventParticipantInfoTypeUsage.Add((EventParticipantInfoTypeUsage)entity);// = new List<EventParticipantInfoTypeUsage>();
                    break;
                case "EventParticipantRelation":
                    listEventParticipantRelation.Add((EventParticipantRelation)entity);// = new List<EventParticipantRelation>();
                    break;
                case "EventParticipantRestriction":
                    listEventParticipantRestriction.Add((EventParticipantRestriction)entity);// = new List<EventParticipantRestriction>();
                    break;
                case "EventStatus":
                    listEventStatus.Add((EventStatus)entity);// = new List<EventStatus>();
                    break;
                case "EventTemplate":
                    listEventTemplate.Add((EventTemplate)entity);// = new List<EventTemplate>();
                    break;
                case "EventType":
                    listEventType.Add((EventType)entity);// = new List<EventType>();
                    break;
                case "EventTypeUsage":
                    listEventTypeUsage.Add((EventTypeUsage)entity);// = new List<EventTypeUsage>();
                    break;
                case "Language":
                    listLanguage.Add((Language)entity);// = new List<Language>();
                    break;
                case "Location":
                    listLocation.Add((Location)entity);// = new List<Location>();
                    break;
                case "LocationRelation":
                    listLocationRelation.Add((LocationRelation)entity);// = new List<LocationRelation>();
                    break;
                case "LocationRelationType":
                    listLocationRelationType.Add((LocationRelationType)entity);// = new List<LocationRelationType>();
                    break;
                case "LocationType":
                    listLocationType.Add((LocationType)entity);// = new List<LocationType>();
                    break;
                case "Market":
                    listMarket.Add((Market)entity);// = new List<Market>();
                    break;
                case "MarketOutcomeRelation":
                    listMarketOutcomeRelation.Add((MarketOutcomeRelation)entity);// = new List<MarketOutcomeRelation>();
                    break;
                case "Outcome":
                    listOutcome.Add((Outcome)entity);// = new List<Outcome>();
                    break;
                case "OutcomeParticipantRelation":
                    listOutcomeParticipantRelation.Add((OutcomeParticipantRelation)entity);// = new List<OutcomeParticipantRelation>();
                    break;
                case "OutcomeStatus":
                    listOutcomeStatus.Add((OutcomeStatus)entity);// = new List<OutcomeStatus>();
                    break;
                case "OutcomeType":
                    listOutcomeType.Add((OutcomeType)entity);// = new List<OutcomeType>();
                    break;
                case "OutcomeTypeBettingTypeRelation":
                    listOutcomeTypeBettingTypeRelation.Add((OutcomeTypeBettingTypeRelation)entity);// = new List<OutcomeTypeBettingTypeRelation>();
                    break;
                case "OutcomeTypeUsage":
                    listOutcomeTypeUsage.Add((OutcomeTypeUsage)entity);// = new List<OutcomeTypeUsage>();
                    break;
                case "Participant":
                    listParticipant.Add((Participant)entity);// = new List<Participant>();
                    break;
                case "ParticipantRelation":
                    listParticipantRelation.Add((ParticipantRelation)entity);// = new List<ParticipantRelation>();
                    break;
                case "ParticipantRelationType":
                    listParticipantRelationType.Add((ParticipantRelationType)entity);// = new List<ParticipantRelationType>();
                    break;
                case "ParticipantRole":
                    listParticipantRole.Add((ParticipantRole)entity);// = new List<ParticipantRole>();
                    break;
                case "ParticipantType":
                    listParticipantType.Add((ParticipantType)entity);// = new List<ParticipantType>();
                    break;
                case "ParticipantTypeRoleUsage":
                    listParticipantTypeRoleUsage.Add((ParticipantTypeRoleUsage)entity);// = new List<ParticipantTypeRoleUsage>();
                    break;
                case "ParticipantUsage":
                    listParticipantUsage.Add((ParticipantUsage)entity);// = new List<ParticipantUsage>();
                    break;
                case "Provider":
                    listProvider.Add((Provider)entity);// = new List<Provider>();
                    break;
                case "ProviderEntityMapping":
                    listProviderEntityMapping.Add((ProviderEntityMapping)entity);// = new List<ProviderEntityMapping>();
                    break;
                case "ProviderEventRelation":
                    listProviderEventRelation.Add((ProviderEventRelation)entity);// = new List<ProviderEventRelation>();
                    break;
                case "ScoringUnit":
                    listScoringUnit.Add((ScoringUnit)entity);// = new List<ScoringUnit>();
                    break;
                case "Source":
                    listSource.Add((Source)entity);// = new List<Source>();
                    break;
                case "Sport":
                    listSport.Add((Sport)entity);// = new List<Sport>();
                    break;
                case "StreamingProvider":
                    listStreamingProvider.Add((StreamingProvider)entity);// = new List<StreamingProvider>();
                    break;
                case "StreamingProviderEventRelation":
                    listStreamingProviderEventRelation.Add((StreamingProviderEventRelation)entity);// = new List<StreamingProviderEventRelation>();
                    break;
                case "Translation":
                    listTranslation.Add((Translation)entity);// = new List<Translation>();
                    break;
                default:
                    break;
            }
        }
    }
}
