using System;
using Sitecore.Analytics.Aggregation.Data.Model;
using Sitecore.ExperienceAnalytics.Aggregation.FlexibleMetrics.Framework.Metrics;

namespace Sitecore.Support.ExperienceAnalytics.Aggregation.FlexibleMetrics.Goal
{
    internal class GoalMetrics : DictionaryValue, IMergeableMetric<GoalMetrics>
    {
        public int Visits { get; set; }

        public int Value { get; set; }

        public int Conversions { get; set; }

        public int Count { get; set; }

        public GoalMetrics MergeWith(GoalMetrics other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            return new GoalMetrics
            {
                Visits = Visits += other.Visits,
                Value = Value += other.Value,
                Conversions = Conversions += other.Conversions,
                Count = Count += other.Count
            };
        }
    }
}