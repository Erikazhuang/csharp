using System;
using FluentApi.Entity;

namespace FluentApi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GeneratePlanRequest request = new GeneratePlanRequest.Builder()
                                                                .withCountry("UK")
                                                                .withComputationType("Refresh")
                                                                .build();
            Console.WriteLine(  request.ToString());
        }
    }
}
