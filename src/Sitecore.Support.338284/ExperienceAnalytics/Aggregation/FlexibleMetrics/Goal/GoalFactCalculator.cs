using System;
using System.Linq;
using Sitecore.Analytics.Aggregation;
using Sitecore.ExperienceAnalytics.Aggregation.FlexibleMetrics.Framework.FactCalculation;
using Sitecore.ExperienceAnalytics.Aggregation.FlexibleMetrics.Framework.Grouping;

namespace Sitecore.Support.ExperienceAnalytics.Aggregation.FlexibleMetrics.Goal
{
    internal class GoalFactCalculator : IFactCalculator<GoalMetrics, XConnect.Goal>
    {
        public GoalMetrics CalculateFactsForGroup(
            VisitGroupMeasurement<XConnect.Goal> groupMeasurement,
            IInteractionAggregationContext context)
        {
            if (groupMeasurement == null)
            {
                throw new ArgumentNullException(nameof(groupMeasurement));
            }

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return new GoalMetrics
            {
                Visits = 1,
                Value = groupMeasurement.Occurrences.Sum(evt => evt.EngagementValue),
                Conversions = context.Interaction.Events.Count(evt => evt is XConnect.Goal),
                Count = groupMeasurement.Occurrences.Count()
            };
        }
    }
}