

using System.Runtime.Serialization;
using FileHelpers;

namespace TTSApp {

    [DataContract] 
    [DelimitedRecord(",")]
    public class FemaleDatasetRecord
    {
        [DataMember] public long fips {get; set;}

        [DataMember] public string area_name {get; set;}
        [DataMember] public string state_abbreviation {get; set;}
        [DataMember][FieldConverter(ConverterKind.Decimal, ".")] public decimal SBO015207 {get; set;} 

    }
}