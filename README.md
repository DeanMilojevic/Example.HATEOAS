# HATEOAS

Implementing the HATEOAS (Hypermedia as the Engine of Application State) has some flavours throught the world.

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

The following examples will show on how this reflects on our responses/resources that we return to our clients.

## Single item resource

In case that we have the single item resource, the guideliness tell us we should return the resource and links that we "allow" to performed further.

The example bellow shows how this looks like:

```json
{
    "id": 1,
    "firstName": "FirstName",
    "lastName": "LastName",
    "links": [
        {
            "method": "GET",
            "rel": "self",
            "href": "http://domain/api/authors/1",
        },
        {
            "method": "DELETE",
            "rel": "delete_author",
            "href": "http://domain/api/authors/1",
        },
        {
            "method": "GET",
            "rel": "get_courses",
            "href": "http://domain/api/authors/1/courses",
        }
    ]
}
```

## Collection of resources

When we have collection of the resources:

```json
{
    "value": [..., ...],
    "links": [..., ...]
}
```

## Reasoning

## Resources

[JSON:API](https://jsonapi.org/)
