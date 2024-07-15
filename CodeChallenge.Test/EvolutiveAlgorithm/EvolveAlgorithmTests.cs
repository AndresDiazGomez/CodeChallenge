using CodeChallenge.EvolutiveAlgorithm;
using System.Globalization;
using Xunit;
using System.Collections.Generic;
using System.Diagnostics;

namespace CodeChallenge.Test.EvolutiveAlgorithm;

public class EvolveAlgorithmTests
{
    [Fact]
    public void EvolveAlgorithm_Resolve_ReturnsAnArrayOfGenerations()
    {
        var algorithm = new EvolveAlgorithm("MVM INGENIERIA DE SOFTWARE VS INGENEO DESARROLLO Y COMPANIA");

        int i = 1;
        algorithm.OnNewGenerationCreated += (sender, e) =>
        {
            Assert.Equal(i, e.Iteration);
            Assert.NotNull(e.Mutation.Current);
            Assert.True(e.Mutation.CurrentScore >= 0);
            Assert.True(e.Mutation.CurrentScore >= 0);
            Assert.True(e.Mutation.SucessRate >= 0);
            Debug.Print($"Generation: {e.Iteration} - Mutation: {e.Mutation.Current} - Score: {e.Mutation.CurrentScore} - Rate: {e.Mutation.SucessRate.ToString("P", CultureInfo.InvariantCulture)}");
            i++;
        };

        List<Generation> result = algorithm.Resolve(50);

        Assert.NotEmpty(result);
    }
}
