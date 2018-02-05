# Currency Exchange API

Currency Exchange is a free API for current foreign exchange rates published by different providers such as [**Fixer**](http://fixer.io/), [**currencylayer**](https://currencylayer.com/) etc. 

A public instance of the API lives at [**https://currency-exchange.apphb.com**](https://currency-exchange.apphb.com) and is proudly hosted on [**AppHarbor**](https://appharbor.com/). As of today, the supported providers are **Fixer**, **currencylayer** and [**currencyconverterapi**](https://free.currencyconverterapi.com/). The other providers such as [**1Forge**](https://1forge.com/forex-data-api) etc. are under development.

The intention of this API is to bring multiple other currency conversion APIs under one hood. The Currency Exchange API does not store any rates and instead invokes the provider APIs to obtain the latest exchange rates. Thus the available or supported currencies depends solely on the provider. In essence, Currency Exchange API can be thought of as a proxy.


## Usage

### Fixer
Get the latest foreign currency exchange rates from **Fixer**. In order to specify the provider or the source of rates, use the query parameter called `provider`.

#### Endpoint
```http
GET /api/rates?provider=fixer&fr=USD&to=INR
```

#### Response Format
Currency Exchange API supports two formats: `text` and `json`. In order to specify the format, use the query parameter called `format`. The default response format is `text`.

```http
GET /api/rates?provider=fixer&fr=USD&to=INR&format=text
```

```http
GET /api/rates?provider=fixer&fr=USD&to=INR&format=json
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
To know about the currencies supported by Fixer, please refer: [**http://fixer.io/**](http://fixer.io/)

#### Try it Out!
Click this link to obtain the current rate for 1 USD in INR: [**https://currency-exchange.apphb.com/api/rates?provider=fixer&fr=USD&to=INR**](https://currency-exchange.apphb.com/api/rates?provider=fixer&fr=USD&to=INR)

### Currency Layer
Get the latest foreign currency exchange rates from **currencylayer.com**. In order to specify the provider or the source of rates, use the query parameter called `provider`.

#### Endpoint
```http
GET /api/rates?provider=currencylayer&apikey=[YOUR_API_KEY]&fr=USD&to=INR
```

#### Response Format
Currency Exchange API supports two formats: `text` and `json`. In order to specify the format, use the query parameter called `format`. The default response format is `text`.

```http
GET /api/rates?provider=currencylayer&apikey=[YOUR_API_KEY]&fr=USD&to=INR&format=text
```

```http
GET /api/rates?provider=currencylayer&apikey=[YOUR_API_KEY]&fr=USD&to=INR&format=json
```

A JSON response would be structured like as shown below:

```json
{
   "success":true,
   "terms":"https:\/\/currencylayer.com\/terms",
   "privacy":"https:\/\/currencylayer.com\/privacy",
   "timestamp":1517758336,
   "source":"USD",
   "quotes":{
      "USDINR":64.119003
   }
}
```

#### Supported Rates
To know about the currencies supported by currencylayer, please refer: [**https://currencylayer.com/**](https://currencylayer.com/).

> currencylayer's free plan only supports **USD** as the source/from currency.

#### Try it Out!
Click this link to obtain the current rate for 1 USD in INR: [**https://currency-exchange.apphb.com/api/rates?apikey=0437ce11a7751b8b4e8af994486a1d9d&provider=currencylayer&fr=USD&to=INR**](https://currency-exchange.apphb.com/api/rates?apikey=0437ce11a7751b8b4e8af994486a1d9d&provider=currencylayer&fr=USD&to=INR)

> Please do not use the API Key used in the above sample call for any live applications.

### Currency Converter API
Get the latest foreign currency exchange rates from **currencyconverterapi.com**. In order to specify the provider or the source of rates, use the query parameter called `provider`.

#### Endpoint
```http
GET /api/rates?provider=currencyconverterapi&fr=USD&to=INR
```

#### Response Format
Currency Exchange API supports two formats: `text` and `json`. In order to specify the format, use the query parameter called `format`. The default response format is `text`.

```http
GET /api/rates?provider=currencyconverterapi&fr=USD&to=INR&format=text
```

```http
GET /api/rates?provider=currencyconverterapi&fr=USD&to=INR&format=json
```

A JSON response would be structured like as shown below:

```json
{
   "query":{
      "count":1
   },
   "results":{
      "USD_INR":{
         "id":"USD_INR",
         "val":64.112503,
         "to":"INR",
         "fr":"USD"
      }
   }
}
```

#### Supported Rates
To know about the currencies supported by currencyconverterapi.com, please refer: [**https://free.currencyconverterapi.com/**](https://free.currencyconverterapi.com/)

#### Try it Out!
Click this link to obtain the current rate for 1 USD in INR: [**https://currency-exchange.apphb.com/api/rates?provider=currencyconverterapi&fr=USD&to=INR**](https://currency-exchange.apphb.com/api/rates?provider=currencyconverterapi&fr=USD&to=INR)

## To Dos
- [x] Add support for currencylayer.com
- [x] Add support for currencyconverterapi.com
- [ ] Add support for 1Forge.com
- [ ] Better Exception Handling
- [ ] More Unit Tests
- [ ] Add an index.html to the live site with proper description as in the Readme.md

## License
Code is under the **MIT License**.
Documentation is under the [MIT License](https://opensource.org/licenses/MIT).

## Disclaimer
> The API comes with no warranty. Please cache results whenever possible.
