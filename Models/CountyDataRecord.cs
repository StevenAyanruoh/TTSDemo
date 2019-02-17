

using System.Runtime.Serialization;
using FileHelpers;

namespace TTSApp {

    [DataContract] 
    [DelimitedRecord(",")]
    public class CountyDataRecord
    {
        [DataMember] public long fips {get; set;}

        [DataMember] public string area_name {get; set;}
        [DataMember] public string state_abbreviation {get; set;}
        public long PST045214 {get; set;}
        public long PST040210 {get; set;}
        [FieldConverter(ConverterKind.Decimal, ".")]  public decimal PST120214 {get; set;}
        public long POP010210 {get; set;}
        [FieldConverter(ConverterKind.Decimal, ".")] public decimal AGE135214 {get; set;}
        [FieldConverter(ConverterKind.Decimal, ".")] public decimal AGE295214 {get; set;}
        [FieldConverter(ConverterKind.Decimal, ".")] public decimal AGE775214 {get; set;}
        [FieldConverter(ConverterKind.Decimal, ".")] public decimal SEX255214 {get; set;}
        [FieldConverter(ConverterKind.Decimal, ".")]  public decimal RHI125214 {get; set;}
        [FieldConverter(ConverterKind.Decimal, ".")] public decimal RHI225214 {get; set;}	
        [FieldConverter(ConverterKind.Decimal, ".")] public decimal RHI325214 {get; set;}
        [FieldConverter(ConverterKind.Decimal, ".")] public decimal RHI425214 {get; set;}
        [FieldConverter(ConverterKind.Decimal, ".")] public decimal RHI525214 {get; set;}		
        [FieldConverter(ConverterKind.Decimal, ".")] public decimal RHI625214 {get; set;}
        [FieldConverter(ConverterKind.Decimal, ".")] public decimal RHI725214 {get; set;}
        [FieldConverter(ConverterKind.Decimal, ".")] public decimal RHI825214 {get; set;}
        [FieldConverter(ConverterKind.Decimal, ".")] public decimal POP715213 {get; set;}
        [FieldConverter(ConverterKind.Decimal, ".")] public decimal POP645213 {get; set;}
        [FieldConverter(ConverterKind.Decimal, ".")] public decimal POP815213 {get; set;}	
        [FieldConverter(ConverterKind.Decimal, ".")] public decimal EDU635213 {get; set;}
        [FieldConverter(ConverterKind.Decimal, ".")] public decimal EDU685213 {get; set;}
        public long VET605213 {get; set;}
        [FieldConverter(ConverterKind.Decimal, ".")] public decimal LFE305213 {get; set;}	
        public long HSG010214 {get; set;}
        [FieldConverter(ConverterKind.Decimal, ".")] public decimal HSG445213 {get; set;}
        [FieldConverter(ConverterKind.Decimal, ".")] public decimal HSG096213 {get; set;}	
        public long HSG495213 {get; set;}	
        public long HSD410213 {get; set;}	
        [FieldConverter(ConverterKind.Decimal, ".")] public decimal HSD310213 {get; set;}	
        public long INC910213 {get; set;}	
        public long INC110213 {get; set;}	
        [FieldConverter(ConverterKind.Decimal, ".")] public decimal PVY020213 {get; set;}	
        public long BZA010213 {get; set;}	
        public long BZA110213 {get; set;}		
        [FieldConverter(ConverterKind.Decimal, ".")] public decimal BZA115213 {get; set;}	
        public long NES010213 {get; set;}	
        public long SBO001207 {get; set;}	
        [FieldConverter(ConverterKind.Decimal, ".")] public decimal SBO315207 {get; set;}	
        [FieldConverter(ConverterKind.Decimal, ".")] public decimal SBO115207 {get; set;}
        [FieldConverter(ConverterKind.Decimal, ".")] public decimal SBO215207 {get; set;}
        [FieldConverter(ConverterKind.Decimal, ".")] public decimal SBO515207 {get; set;}
        [FieldConverter(ConverterKind.Decimal, ".")] public decimal SBO415207 {get; set;}
        [DataMember][FieldConverter(ConverterKind.Decimal, ".")] public decimal SBO015207 {get; set;}
        public long MAN450207 {get; set;}	
        public long WTN220207 {get; set;}
        public long RTN130207 {get; set;}	
        public long RTN131207 {get; set;}
        public long AFN120207 {get; set;}	
        public long BPS030214 {get; set;}		
        [FieldConverter(ConverterKind.Decimal, ".")] public decimal LND110210 {get; set;}
        [FieldConverter(ConverterKind.Decimal, ".")] public decimal POP060210 {get; set;}	

    }
}