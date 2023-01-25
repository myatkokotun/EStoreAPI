
# EStore API

For first use, need to generate code numbers by calling gererate code api. This project includes generating promotion codes and insert with EVoucher.


## API Reference
Base URL "http://localhost:5195/"
#### Get Geterate Code no

```http
  GET /api/PromoCodeContorller/GenerateCodeNo
```

#### Get PromoCode List

```http
  GET /api/PromoCodeContorller/GetPromoCodeList
```

#### Get PromoCode Detail

```http
  GET /api/PromoCodeContorller/GetPromoCodeObj
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. Id of item to fetch |

#### Detete PromoCode

```http
  GET /api/PromoCodeContorller/DeletePromoCode
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. Id of item to fetch |

#### Insert PromoCode with EVoucher

```http
  GET /api/PromoCodeContorller/UpSertPromoCode
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `EVid`      | `int` | **Required**.  |
|`Phone`|`string`|**Required**.  |