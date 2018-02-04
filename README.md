# Currency Exchange API

Currency Exchange is a free API for current foreign exchange rates published by different providers such as [**Fixer**](http://fixer.io/), [**currencylayer**](https://currencylayer.com/) etc. 

A public instance of the API lives at **https://currency-exchange.apphb.com** and is proudly hosted on [**AppHarbor**](https://appharbor.com/). As of today, the only supported provider is **Fixer**. The other providers such as **currencylayer**, [**1Forge**](https://1forge.com/forex-data-api) etc. are under development.

The intention of this API is to bring multiple other currency conversion APIs under one hood. The Currency Exchange API does not store any rates and instead invokes the provider APIs to obtain the latest exchange rates. Thus the available or supported currencies depends solely on the provider. In essence, Currency Exchange API can be thought of as a proxy.


## Usage

### _Provider_: Fixer
Get the latest foreign currency exchange rates from **Fixer**. In order to specify the provider or the source of rates, use the query parameter called `provider`.

#### Endpoint
```http
GET /api/rates?provider=fixer&from=USD&to=INR
```

#### Response Format
Currency Exchange API supports two formats: `text` and `json`. In order to specify the format, use the query parameter called `format`. The default response format is `text`.

```http
GET /api/rates?provider=fixer&from=USD&to=INR&format=text
```

```http
GET /api/rates?provider=fixer&from=USD&to=INR&format=json
```

A JSON response would be structured like as shown below:

```json
{  
   "base":"USD",
   "date":"2018-02-02",
   "rates":{  
      "INR":64.057
   }
}
```

#### Supported Rates
To know about the currencies supported by Fixer, please refer: https://api.fixer.io/latest

#### Try it out!
Click on this link to initiate a `GET` request: **https://currency-exchange.apphb.com/api/rates?provider=fixer&from=USD&to=INR**

## License
Code is under the **MIT License**.
Documentation is under the [MIT License](https://opensource.org/licenses/MIT).

## Disclaimer
> The API comes with no warranty. Please cache results whenever possible.
