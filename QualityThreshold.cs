using System.ComponentModel;

namespace GildedRose
{
    public enum QualityThreshold
    {
        [Description("3")]
        TripleQuality = 6,
        [Description("2")]
        DoubleQuality = 11,
        [Description("1")]
        MaxQuality = 50,
        OverNineThousand = 9000
    }
}
