# HATEOAS (WIP)

Implementing the HATEOAS (Hypermedia as the Engine of Application State) has some flavours throught the world. When implementing HATEOS in the design of the API, there are some guidelines we need to follow (well, standards to be exact). This is something that keeps growing and chaning over time, but some of the examples of standards are *OData*, *HAL*, *Siren*, etc.

One of the things that this standards provide as a guideline is formatting of the links/actions/endpoints client will get together with resource:

```json
{
    "links": [
        {
            "method": "GET",
            "rel": "get-authors",
            "href": "http://domain/api/authors"
        }
    ]
}
```

From this, the client of the API should care about the *rel*. This is the "key" it will use to identify a specific action it wants to execute agains our API. Other than that, if something in the endpoint changes (parameters are added/removed, etc.) it will not care. It will not be a breaking change, as the proper URI will be created by the server. If we add something to the API, client can just ignore this new link till it is ready to implement it.

This is one powerful way to make self-describing and open to evolve API. It introduces some complexity on the implementation side, while it also alows flexibility on the other.

The following examples will show on how this reflects on our responses/resources that we return to our clients.

## Single item resource

In case that we have the single item resource, the guideliness tell us we should return the resource and links that we "allow" to performed further. The example bellow shows how this looks like:

```json
{
    "id": 1,
    "firstName": "FirstName",
    "lastName": "LastName",
    "links": [
        {
            "method": "GET",
            "rel": "self",
            "href": "http://domain/api/authors/1"
        },
        {
            "method": "DELETE",
            "rel": "delete_author",
            "href": "http://domain/api/authors/1"
        },
        {
            "method": "GET",
            "rel": "get_courses",
            "href": "http://domain/api/authors/1/courses"
        }
    ]
}
```

## Collection of resources

In case of the collection of the resources:

```json
{
    "value": [
        {
            "id": 1,
            "firstName": "FirstName",
            "lastName": "LastName",
            "links": [
                {
                    "method": "GET",
                    "rel": "self",
                    "href": "http://domain/api/authors/1"
                },
                {
                    "method": "DELETE",
                    "rel": "delete_author",
                    "href": "http://domain/api/authors/1"
                },
                {
                    "method": "GET",
                    "rel": "get_courses",
                    "href": "http://domain/api/authors/1/courses"
                }
            ]
        },
        {
            "id": 2,
            "firstName": "FirstName",
            "lastName": "LastName",
            "links": [
                {
                    "method": "GET",
                    "rel": "self",
                    "href": "http://domain/api/authors/2"
                },
                {
                    "method": "DELETE",
                    "rel": "delete_author",
                    "href": "http://domain/api/authors/2"
                },
                {
                    "method": "GET",
                    "rel": "get_courses",
                    "href": "http://domain/api/authors/2/courses"
                }
            ]
        }
    ],
    "links": [
        {
            "method": "GET",
            "rel": "previous_page",
            "href": "http://domain/api/authors?page=1&howMany=10"
        },
        {
            "method": "GET",
            "rel": "self",
            "href": "http://domain/api/authors?page=2&howMany=10"
        },
        {
            "method": "GET",
            "rel": "next_page",
            "href": "http://domain/api/authors?page=3&howMany=10"
        }
    ]
}
```

Next to this, we also return some information, as part of the header.

```json
    "X-Pagination":
    { "totalCount":3, "pageSize":10, "currentPage":1, "totalPages":1 }
```

This is metadata about the *pagination* itself. Honestly, it is up to implementer and his choosen way on how to return this information. This can also be part of the "envelope" instead of adding a header. As most of the things in programming, this is a matter of preference/opinion/likes/etc. Here, I went with a header approach, but maybe in some other controller in this example I will showcase this as part of the "envelope".

## Resources & data shaping

This allows to clients of the API to specify what piece of the resource data they need. This will reduce overfetching of the data and improve overall design of the API. One way to look at this, is to allow clients to define the "views" on top of the resource (think GraphQL).

Example:

```json
GET http://domain/api/authors?fields=firstName,lastName

{
  "value": [
    {
      "FirstName": "FirstName",
      "LastName": "LastName",
      "links": [
        {
          "method": "GET",
          "rel": "self",
          "href": "http://domain/api/authors/f76f5345-a714-4d92-994d-b4b5a337cba7"
        },
        {
          "method": "DELETE",
          "rel": "delete_author",
          "href": "http://domain/api/authors/f76f5345-a714-4d92-994d-b4b5a337cba7"
        }
      ]
    },
    {
      "FirstName": "FirstName",
      "LastName": "LastName",
      "links": [
        {
          "method": "GET",
          "rel": "self",
          "href": "http://domain/api/authors/fae2bf06-a3af-451b-ad0a-6f34c1378fb2"
        },
        {
          "method": "DELETE",
          "rel": "delete_author",
          "href": "http://domain/api/authors/fae2bf06-a3af-451b-ad0a-6f34c1378fb2"
        }
      ]
    },
    {
      "FirstName": "FirstName",
      "LastName": "LastName",
      "links": [
        {
          "method": "GET",
          "rel": "self",
          "href": "http://domain/api/authors/47782987-5513-4929-994c-55dbb27bf7bc"
        },
        {
          "method": "DELETE",
          "rel": "delete_author",
          "href": "http://domain/api/authors/47782987-5513-4929-994c-55dbb27bf7bc"
        }
      ]
    }
  ],
  "links": [
    {
      "method": "GET",
      "rel": "self",
      "href": "http://domain/api/authors?Page=1&HowMany=10&Fields=firstName,lastName"
    }
  ]
}
```

## Content negotiation and media types

When venturing in this waters, one additional things keeps showing. Is this anymore `application/json` or is it something new? The client of our API made a request, but will it know what to do about it? It is not "just" resource data anymore. There is much more information now.

This is where the journey start and the complexity of our implementation keeps increasing. For better, in my opinion.

Now the data is enriched, so to say. It comes with some contextual information that give more meaning about the API. Popular term is that comes in an "envelope". On the other hand, *HTTP* is an "envelope" already. Not gonna dive into that discussion here.

For now focus of this should be, what do we tell client about the content API is going to return?

We can move that responsibility to the client as well. If client wants the `application/json` API can return only resource information. Nothing more. No envelope or extra information.

This means that if we can multiple representations of the resource, we can define multiple media types that API will support. The good practice is to have the *default* media type as well. In todays day and age, the safe bet is `application/json`.

## Resources

[JSON:API](https://jsonapi.org/)  
[OData](https://www.odata.org/)  
[Siren](https://github.com/kevinswiber/siren)  
[HAL](http://stateless.co/hal_specification.html)  
