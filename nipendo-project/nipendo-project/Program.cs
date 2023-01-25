using nipendo_project.Services.Implementations;
using nipendo_project.Services.Interfaces;
using System;
using static nipendo_project.Utils.Logger;

namespace nipendo_project
{
    internal class Program
    {
        private readonly IRatingEngineService _engine;
        private readonly IJsonService _jsonService;
        private readonly IPolicyReaderService _policyReaderService;

        public Program()
        {
            _engine = new RatingEngineService();
            _jsonService = new JsonService();
            _policyReaderService = new PolicyReaderService();
        }

        static void Main(string[] args)
        {
            var program = new Program();
            program.Run();
        }

        private void Run()
        {
            var logger = new LogDelegate(Console.WriteLine);
            logger("Insurance Rating System Starting...");

            try
            {
                // Getting all the essentail data
                const string JSON_PATH = "../../../policy.json";
                var rawPolicy = _jsonService.Deserialize<dynamic>(JSON_PATH);
                var policy = _policyReaderService.GetDataFromJson(rawPolicy);

                // Rating logic
                _engine.Rate(policy, logger);
                if (_engine.Rating > 0)
                {
                    logger($"Rating: {_engine.Rating}");
                    Console.ReadKey();
                }
                else
                {
                    logger("No rating produced.");
                }
            }
            catch (Exception ex)
            {
                logger(ex.ToString());
            }
        }
    }
}
