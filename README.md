# Claytondus.Square

## This project references the Square Connect v1 API, which is mostly deprecated at this point.  Please use the official Square .NET SDK at https://github.com/square/square-dotnet-sdk/.




A C# wrapper for the Square Connect API.  I AM NOT AFFILIATED WITH SQUARE, INC. IN ANY WAY.

At the moment, Payments, Orders, Items, Variations, Modifier Lists/Options, Categories, Fees, and OAuth are supported.  Rudimentary batch support is available, but there is no type support for creating requests.

Other parts of the Connect API may be implemented as requested.  Pull requests are welcome.

### Installation
Use `dotnet add package Claytondus.Square` to install.

### Usage
    using Claytondus.Square;
	var itemClient = new SquareItemClient("my-access-token","my-location-id");
	var items = await itemClient.ListItemsAsync();
