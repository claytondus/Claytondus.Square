# Claytondus.Square
A C# wrapper for the Square Connect API.  I AM NOT AFFILIATED WITH SQUARE, INC. IN ANY WAY.

At the moment, Payments, Orders, Items, Variations, Modifier Lists/Options, Categories, Fees, and OAuth are supported.  Rudimentary batch support is available, but there is no type support for creating requests.

Other parts of the Connect API may be implemented as requested.  Pull requests are welcome.

###Installation
Use `Install-Package Claytondus.Square` to install.

###Usage
    using Claytondus.Square;
	var itemClient = new SquareItemClient("my-access-token","my-location-id");
	var items = await itemClient.ListItemsAsync();