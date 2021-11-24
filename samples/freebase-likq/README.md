# freebase-likq: LIKQ for Freebase

In this sample project, we demonstrate how to serve LIKQ queries for
the [Freebase](https://en.wikipedia.org/wiki/Freebase) data set.  It
generally takes the following 3 steps to serve LIKQ queries for a data
set:

- Specify the storage schema for the data in [TSL](https://www.graphengine.io/docs/manual/TSL/index.html). Remember to tag graph edges using [GraphEdge] [attribute](https://www.graphengine.io/docs/manual/TSL/tsl-basics.html#attributes) in the TSL script.
- Import data into Graph Engine.
- Create a C# project to implement a TrinityServer. The C# project need to reference GraphEngine.LIKQ and register the LIKQ module (refer to the sample code for an example).

For brevity, in this sample project we focus on how to serve LIKQ
queries with a prebuilt data image.  Please refer to the
`GraphEngine.DataImporter` project to see how to automatically
generate a schema file and import data.

LIKQ module does not provide a built-in index backend. In this sample
project, a sample index backend based on SQLite is provided.  When
query constraints are specified in a LIKQ query, the LIKQ module calls
a registered index backend to retrieve the graph nodes satisfying the
constraints.  The constraints are specified in a _match_ object, which
is a json object. LIKQ does not parse the _match_ object; it will
relay the _match_ object to the index backend and let the index
backend to interpret the constraints specified by the _match_ object.

## Building and running the demo

Note that the full Freebase image is ~`32GB` so make sure that you run the demo on a beefy server!
We also have prepared a smaller dataset `freebase-film-dataset.zip`. Both datasets are supported,
and we have prepared two separate executables.

After the freebase-likq solution is built successfully, run
`freebase-likq.exe` or `freebase-film-likq.exe`. 
It will automatically download Freebase graph image, 
build SQLite index and start serving LIKQ.  

To enable the LIKQ HTTP endpoint, either run the program 
as administrator, or grant the current user the permission 
to listen to port 80: 
`netsh http add urlacl url=http://+:80/ user=Domain\username`.

Now you can query Freebase via LIKQ. Here is a quick example:

```
//Find wives of Tom Cruise through a 2-hop graph traversal.
Freebase
	.StartFrom(530972568887245, select: new[]{"type_object_name"})
	.FollowEdge("people_person_spouse_s")
	.VisitNode(Action.Continue)
	.FollowEdge("people_marriage_spouse")
	.VisitNode(Action.Return, select: new[]{"type_object_name"});
```

To issue this query via RESTful API, POST the query payload to `http://server/LIKQ/LambdaQuery/`:

```
{
	"lambda": "Freebase
	.StartFrom(530972568887245, select: new[]{\"type_object_name\"})
	.FollowEdge(\"people_person_spouse_s\")
	.VisitNode(Action.Continue)
	.FollowEdge(\"people_marriage_spouse\")
	.VisitNode(Action.Return, select: new[]{\"type_object_name\"});"
}
```

And the result shall look like this:

```
{
    "Results":
[[{"CellId":530972568887245,"type_object_name":"Tom Cruise"},{"CellId":332530798387447},{"CellId":547400553082314,"type_object_name":"Nicole Kidman"}],[{"CellId":530972568887245,"type_object_name":"Tom Cruise"},{"CellId":290269080985430},{"CellId":435682361078655,"type_object_name":"Mimi Rogers"}],[{"CellId":530972568887245,"type_object_name":"Tom Cruise"},{"CellId":438165252269041},{"CellId":524140155134870,"type_object_name":"Katie Holmes"}],[{"CellId":530972568887245,"type_object_name":"Tom Cruise"},{"CellId":292606011314464},{"CellId":360255961521166,"type_object_name":"Penélope Cruz"}]]
}
```

Another example:

```
//Random facts about Beijing
{
	"lambda": "Freebase
	.StartFrom(297095894548906, select: new[]{\"type_object_name\"})
	.VisitNode(_ => _.continue_if(_.dice(0.02)) & _.return_if(_.dice(0.1)), select: new[]{\"type_object_name\"})
	.VisitNode(_ => _.continue_if(_.dice(0.02)) & _.return_if(_.dice(0.1)), select: new[]{\"type_object_name\"})
	.VisitNode(Action.Return);"
}
```

And the result shall be different every time (because we apply sampling of probability 10%):

```
{
    "Results":
[[{"CellId":297095894548906,"type_object_name":"Beijing","graph_outlinks":["travel_travel_destination_visitor_information_site"]},{"CellId":376867967714800,"type_object_name":""}],[{"CellId":297095894548906,"type_object_name":"Beijing","graph_outlinks":["travel_travel_destination_climate"]},{"CellId":365581129565857,"type_object_name":""}],[{"CellId":297095894548906,"type_object_name":"Beijing","graph_outlinks":["travel_travel_destination_climate"]},{"CellId":451288213711482,"type_object_name":""}],[{"CellId":297095894548906,"type_object_name":"Beijing","graph_outlinks":["common_topic_webpage"]},{"CellId":382284952397975,"type_object_name":""}],[{"CellId":297095894548906,"type_object_name":"Beijing","graph_outlinks":["common_topic_webpage"]},{"CellId":459237260174344,"type_object_name":""}],[{"CellId":297095894548906,"type_object_name":"Beijing","graph_outlinks":["travel_travel_destination_climate"]},{"CellId":433800880109811,"type_object_name":""}],[{"CellId":297095894548906,"type_object_name":"Beijing","graph_outlinks":["olympics_olympic_host_city_olympics_hosted"]},{"CellId":294136728044394,"type_object_name":"2008 Summer Olympics"}]]
}
```

## Known issues

- On the full dataset, the SQLite index may be slow.
- The first few queries will trigger JIT compilation of the TSL assembly (which is huge!), so they may appear to be slow. After a few queries the assembly should be mostly JIT'ed (due to high connectedness in the graph).
- The data importer could be further improved. Some edges lack the [GraphEdge] tag, and thus could only be traversed through if explicitly specified. This can be improved when we relax the condition in the data importer for type inference. Once the data importer is improved, this demo shall receive some benefits automatically (smaller data images, faster queries, more interesting results etc.).
