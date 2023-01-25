using nipendo_project.Models;
using nipendo_project.Services.Interfaces;
using System;
using static nipendo_project.Utils.Logger;

namespace nipendo_project.Services.Implementations
{
    internal class RatingEngineService : IRatingEngineService
    {
        public decimal Rating { get; set; }

        public void Rate(IPolicy policy, LogDelegate logger)
        {
            logger("Starting rate.");
            logger("Loading policy.");
            logger($"Rating {policy.Type.ToString().ToUpper()} policy...");
            try
            {
                Rating = policy.Rate();
            }
            catch (Exception ex)
            {
                logger(ex.ToString());
            }
            finally
            {
                logger("Rating completed.");
            }
        }
    }
}
