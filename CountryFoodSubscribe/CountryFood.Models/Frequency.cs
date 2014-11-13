using System.ComponentModel;
namespace CountryFood.Models
{
    public enum Frequency
    {
        [Description("Once a week")]
        Weekly,
        [Description("Twice a month")]
        BiWeekly,
        [Description("Once a month")]
        Monthly,
        [Description("Once a year")]
        Yearly
    }
}
