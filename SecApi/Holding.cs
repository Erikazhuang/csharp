namespace SecApi
{
    public class Holding
    {
         public string NameOfIssuer { get; set; }

         public string TitleOfClass { get; set; }

          public string Cusip { get; set; }

          public long value { get; set; }

          public string InvestmentDiscretion {get; set;}

          public ShrsOrPrnAmt ShrsOrPrnAmt{get;set;}

          public VotingAuthority VotingAuthority{get;set;}

          public override string ToString()
          {
               return "holding " + NameOfIssuer + " " + value;
          }

    }

    public class ShrsOrPrnAmt
    {
         public long SshPrnamt { get; set; }
         public string SshPrnamtType { get; set; }
    }

    public class VotingAuthority
    {
         public long Sole { get; set; }
          public long Shared { get; set; }
           public long None { get; set; }
    }
}