using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;
using Xunit.Abstractions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class ShipTests
{
    private readonly ITestOutputHelper _output;

    public ShipTests(ITestOutputHelper output)
    {
        this._output = output;
        return;
    }

    [Theory]
    [InlineData(239)]
    public void CheckRoutePleasureShuttleShipInNOIDOSERouteFailed(int i)
    {
        var pleasureShuttle = new CreatePleasureShuttle();
        ShipBase pleasureShuttleShip = pleasureShuttle.Ship;
        var environment = new NebulaeOfIncreasedDensityOfSpaceEnvironment(null, i);
        IReadOnlyCollection<EnvironmentBase> curRoute = new Collection<EnvironmentBase> { environment };
        var route = new Route(curRoute);
        var routeShipChecker = new RouteShipChecker();

        ResultOfRoute resultOfRoute = routeShipChecker.CheckRoute(route, pleasureShuttleShip);
        var processResults = new ProcessResults();
        processResults.Process(resultOfRoute);
        _output.WriteLine(processResults.Results);

        Assert.True(!resultOfRoute.IsSucceed);
        Assert.False(resultOfRoute.IsSucceed);
    }

    [Theory]
    [InlineData(239)]
    public void CheckRouteAvgurShipInNOIDOSERouteFailed(int i)
    {
        var avgur = new CreateAvgur();
        ShipBase avgurShip = avgur.Ship;
        var environment = new NebulaeOfIncreasedDensityOfSpaceEnvironment(null, i);
        IReadOnlyCollection<EnvironmentBase> curRoute = new Collection<EnvironmentBase> { environment };
        var route = new Route(curRoute);
        var routeShipChecker = new RouteShipChecker();

        ResultOfRoute resultOfRoute = routeShipChecker.CheckRoute(route, avgurShip);
        var processResults = new ProcessResults();
        processResults.Process(resultOfRoute);
        _output.WriteLine(processResults.Results);

        Assert.True(!resultOfRoute.IsSucceed);
        Assert.False(resultOfRoute.IsSucceed);
    }

    [Theory]
    [InlineData(56)]
    public void CheckRouteVaklasShipNoPhotonDeflectorInNOIDOSEWithFlareRouteFailed(int i)
    {
        var vaklas = new CreateVaklas();
        ShipBase vaklasShip = vaklas.Ship;
        var antimatterFlares = new AntimatterFlares();
        var environment = new NebulaeOfIncreasedDensityOfSpaceEnvironment(antimatterFlares, i);
        IReadOnlyCollection<EnvironmentBase> curRoute = new Collection<EnvironmentBase> { environment };
        var route = new Route(curRoute);
        var routeShipChecker = new RouteShipChecker();

        ResultOfRoute resultOfRoute = routeShipChecker.CheckRoute(route, vaklasShip);
        var processResults = new ProcessResults();
        processResults.Process(resultOfRoute);
        _output.WriteLine(processResults.Results);

        Assert.True(!resultOfRoute.IsSucceed);
        Assert.False(resultOfRoute.IsSucceed);
    }

    [Theory]
    [InlineData(238)]
    public void CheckRouteVaklasShipWithPhotonDeflectorInNOIDOSEWithFlareRouteSucceed(int i)
    {
        var vaklas = new CreateVaklas();
        ShipBase vaklasShip = vaklas.Ship;
        vaklasShip.SetPhotonicDeflector();
        var antimatterFlares = new AntimatterFlares();
        var environment = new NebulaeOfIncreasedDensityOfSpaceEnvironment(antimatterFlares, i);
        IReadOnlyCollection<EnvironmentBase> curRoute = new Collection<EnvironmentBase> { environment };
        var route = new Route(curRoute);
        var routeShipChecker = new RouteShipChecker();

        ResultOfRoute resultOfRoute = routeShipChecker.CheckRoute(route, vaklasShip);
        var processResults = new ProcessResults();
        processResults.Process(resultOfRoute);
        _output.WriteLine(processResults.Results);

        Assert.True(resultOfRoute.IsSucceed);
        Assert.False(!resultOfRoute.IsSucceed);
    }

    [Theory]
    [InlineData(23)]
    public void CheckRouteVaklasShipInNONPEWithCosmoWhaleRouteFailed(int i)
    {
        var vaklas = new CreateVaklas();
        ShipBase vaklasShip = vaklas.Ship;
        var cosmoWhale = new CosmoWhale(1);
        var environment = new NebulaeOfNitrineParticlesEnvironment(cosmoWhale, i);
        IReadOnlyCollection<EnvironmentBase> curRoute = new Collection<EnvironmentBase> { environment };
        var route = new Route(curRoute);
        var routeShipChecker = new RouteShipChecker();

        ResultOfRoute resultOfRoute = routeShipChecker.CheckRoute(route, vaklasShip);
        var processResults = new ProcessResults();
        processResults.Process(resultOfRoute);
        _output.WriteLine(processResults.Results);

        Assert.True(!resultOfRoute.IsSucceed);
        Assert.False(resultOfRoute.IsSucceed);
    }

    [Theory]
    [InlineData(23)]
    public void CheckRouteAvgurShipInNONPEWithCosmoWhaleRouteSucceed(int i)
    {
        var avgur = new CreateAvgur();
        ShipBase avgurShip = avgur.Ship;
        var cosmoWhale = new CosmoWhale(1);
        var environment = new NebulaeOfNitrineParticlesEnvironment(cosmoWhale, i);
        IReadOnlyCollection<EnvironmentBase> curRoute = new Collection<EnvironmentBase> { environment };
        var route = new Route(curRoute);
        var routeShipChecker = new RouteShipChecker();

        ResultOfRoute resultOfRoute = routeShipChecker.CheckRoute(route, avgurShip);
        var processResults = new ProcessResults();
        processResults.Process(resultOfRoute);
        _output.WriteLine(processResults.Results);

        Assert.True(resultOfRoute.IsSucceed);
        Assert.False(!resultOfRoute.IsSucceed);
    }

    [Theory]
    [InlineData(23)]
    public void CheckRouteMeredianShipInNONPEWithCosmoWhaleRouteSucceed(int i)
    {
        var meredian = new CreateMeredian();
        ShipBase meredianShip = meredian.Ship;
        var cosmoWhale = new CosmoWhale(1);
        var environment = new NebulaeOfNitrineParticlesEnvironment(cosmoWhale, i);
        IReadOnlyCollection<EnvironmentBase> curRoute = new Collection<EnvironmentBase> { environment };
        var route = new Route(curRoute);
        var routeShipChecker = new RouteShipChecker();

        ResultOfRoute resultOfRoute = routeShipChecker.CheckRoute(route, meredianShip);
        var processResults = new ProcessResults();
        processResults.Process(resultOfRoute);
        _output.WriteLine(processResults.Results);

        Assert.True(resultOfRoute.IsSucceed);
        Assert.False(!resultOfRoute.IsSucceed);
    }

    [Fact]
    public void FindOptimalShipBetweenPleasureShuttleShipAndVaklasShipInCosmosReturnsPleasureShuttleShip()
    {
        var pleasureShuttle = new CreatePleasureShuttle();
        ShipBase pleasureShuttleShip = pleasureShuttle.Ship;
        var vaklas = new CreateVaklas();
        ShipBase vaklasShip = vaklas.Ship;
        var environment = new CosmosEnvironment(null, null, 5);
        IReadOnlyCollection<EnvironmentBase> curRoute = new Collection<EnvironmentBase> { environment };
        var route = new Route(curRoute);
        var optimalShipFinderByRoute = new OptimalShipFinderByRoute();
        IList<ShipBase> compareTwo = new List<ShipBase> { pleasureShuttleShip, vaklasShip };

        ShipBase? resultShip = optimalShipFinderByRoute.FindBestShip(route, compareTwo);

        Assert.True(resultShip == pleasureShuttleShip);
        Assert.False(resultShip != pleasureShuttleShip);
    }

    [Fact]
    public void FindOptimalShipBetweenAvgurShipAndStellaShipInNOIDOSEReturnsStellaShip()
    {
        var avgur = new CreateAvgur();
        ShipBase avgurShip = avgur.Ship;
        var stella = new CreateStella();
        ShipBase stellaShip = stella.Ship;
        var environment = new NebulaeOfIncreasedDensityOfSpaceEnvironment(null, 239);
        IReadOnlyCollection<EnvironmentBase> curRoute = new Collection<EnvironmentBase> { environment };
        var route = new Route(curRoute);
        var optimalShipFinderByRoute = new OptimalShipFinderByRoute();
        IList<ShipBase> compareTwo = new List<ShipBase> { avgurShip, stellaShip };

        ShipBase? resultShip = optimalShipFinderByRoute.FindBestShip(route, compareTwo);

        Assert.True(resultShip == stellaShip);
        Assert.False(resultShip != stellaShip);
    }

    [Fact]
    public void FindOptimalShipBetweenPleasureShuttleShipAndVaklasShipInNONPEReturnsVaklasShip()
    {
        var pleasureShuttle = new CreatePleasureShuttle();
        ShipBase pleasureShuttleShip = pleasureShuttle.Ship;
        var vaklas = new CreateVaklas();
        ShipBase vaklasShip = vaklas.Ship;
        var environment = new NebulaeOfNitrineParticlesEnvironment(null, 10);
        IReadOnlyCollection<EnvironmentBase> curRoute = new Collection<EnvironmentBase> { environment };
        var route = new Route(curRoute);
        var optimalShipFinderByRoute = new OptimalShipFinderByRoute();
        IList<ShipBase> compareTwo = new List<ShipBase> { pleasureShuttleShip, vaklasShip };

        ShipBase? resultShip = optimalShipFinderByRoute.FindBestShip(route, compareTwo);

        Assert.True(resultShip == vaklasShip);
        Assert.False(resultShip != vaklasShip);
    }

    [Fact]
    public void CheckRouteMeredianShipCustomRouteSucceed()
    {
        var meredian = new CreateMeredian();
        ShipBase meredianShip = meredian.Ship;
        var cosmoWhale = new CosmoWhale(1);
        var environment = new NebulaeOfNitrineParticlesEnvironment(cosmoWhale, 5);
        var environmentSecond = new CosmosEnvironment(null, null, 30);
        IReadOnlyCollection<EnvironmentBase> curRoute = new Collection<EnvironmentBase>
            { environment, environmentSecond };
        var route = new Route(curRoute);
        var routeShipChecker = new RouteShipChecker();

        ResultOfRoute resultOfRoute = routeShipChecker.CheckRoute(route, meredianShip);
        var processResults = new ProcessResults();
        processResults.Process(resultOfRoute);
        _output.WriteLine(processResults.Results);

        Assert.True(resultOfRoute.IsSucceed);
        Assert.False(!resultOfRoute.IsSucceed);
    }
}