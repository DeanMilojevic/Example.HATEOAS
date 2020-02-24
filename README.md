# HATEOAS

Implementing the HATEOAS (Hypermedia as the Engine of Application State) has some flavours throught the world. In this example I am trying 2 of the different ones:

1. Sending metadata using *Headers* of the response.
2. Sending metadata as part of the *Content* of the response.

When implementing HATEOS in the design of the API, there are some guidelines we need to follow. For example, how the links should be returned to the client:

```json
{
    ...,
    "links": [
        ...,
        {
            "method": "GET",
            "rel": "get-authors",
            "href": "http://domain/api/authors",
        },
        ...
    ],
    ...
}
```

From this, the client of the API should care about the *rel*. This is the "key" it will use to identify a specific action it wants to execute agains our API. Other than that, if something in the endpoint changes (parameters are added/removed, etc.) it will not care. It will not be a breaking change, as the proper URI will be created by the server. If we add something to the API, client can just ignore this new link till it is ready to implement it.

This is one powerfull way to make self-describing and open to evolve API. It introduces some complexity on the implementation side, while it also alows flexibility on the other.

When we have collection of the resources:

```json
{
    "value": [..., ...],
    "links": [..., ...]
}
```

## Headers approach

In the example of the controller *AuthorsController*, the metadata about pagination is sent as part of the *X-Pagination* response header.

```json

Example

```

## Envelope/Content approach

In the example of the *CouresController*, the metadata is packaged together with the *Content* of the response. Popular term for this is *Envelope*.

```json

Example

```

## Reasoning

## Resources

[JSON:API](https://jsonapi.org/)
