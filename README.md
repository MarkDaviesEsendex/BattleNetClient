# Battle Net Client
This is a c# library that will allow you to interact with the blizzard apis, in a clean testable way - that's the hope anyway.

# Usage
## Create a client:
```
var client = await _factory.CreateClientAsync("clientId", "clientSecret");
```

*Note*: to aquire a client id and a client seecret please go and see the documentation for the blizzard api: https://develop.battle.net/, I am not in charge of this.

## Check validity
If the api pases back an invalid status code (anything not in the 200 range) the sdk will pass back an invalid client, to check this please use the `IsClientValid` property, the client will allow you to interact with it (specified later in the readme) but will _always_ return invalid results.

Whilst people may disagree with this approach, I always feel that a _good_ library will always return objects that the consuming code can interact with.

## Query the api:
```
var factory = new BattleNetClientFactory(Region.UnitedStates, server.GetClient());
var client = await factory.CreateClientAsync("clientId", "clientSecret");

if(client.IsValid)
{
    // Get act by id
    var actualActResult = await client.Diablo.Act.GetByIdAsync(1);
}
```

This will pass back a result object:
```
public interface IResult<out T>
{
    bool IsValid { get; }
    T Data { get; }
    HttpStatusCode Code { get; }
}
```

## Check validaity
Before using the object check that it is valid:
```
if(actualActResult.IsValid)
{
    // do your thing --- make your body sing
}
```
*Note*: Again if you have an invalid version of the object it will _not_ be null, it will be a real obejct that you can interact with it will just have no value in the properties i.e. string will be empty, ints will be -1.

# Testing
I have split the project into three libraries:
* Client
* Client Tests
* Client Testing

My hope is that I will post both the client and the client testing libraries onto nuget, and you can simply take advantage of the code I've used to test my code, for example, to test acts:
```
// Create fake server
var server = new BattleNetServerBuilder()
    .CreateClientCredentials("clientId", "clientSecret")
    .Build();

// create client with fake server client
_factory = new BattleNetClientFactory(Region.UnitedStates, server.GetClient());

```

Maybe adding configurable data sometime down the line.