# PolyGlot Users API

- [Buber User API](#buber-user-api)
  - [Create User](#create-user)
    - [Create User Request](#create-user-request)
    - [Create User Response](#create-user-response)
  - [Get User](#get-user)
    - [Get User Request](#get-user-request)
    - [Get User Response](#get-user-response)
  - [Update User](#update-user)
    - [Update User Request](#update-user-request)
    - [Update User Response](#update-user-response)
  - [Delete User](#delete-user)
    - [Delete User Request](#delete-user-request)
    - [Delete User Response](#delete-user-response)

## Create User

### Create User Request

```js
POST /user
```

```json
{
    "firstName": "John",
    "lastName": "Doe",
    "email": "J.Doe@gmail.com",
    "password" : "123doe",
    "dateOfBirth" : "1990-01-01",
    "createdDate" : "2021-01-01"
}
```

### Create User Response

```js
201 Created
```

```yml
Location: {{host}}/user/{{id}}
```

```json
{
  "firstName": "John",
  "lastName": "Doe",
  "email": "J.Doe@gmail.com",
  "password": "123doe",
  "dateOfBirth": "1990-01-01T00:00:00",
  "createdDate": "2021-01-01T00:00:00"
}
```

## Get User

### Get User Request

```js
GET /user/{{id}}
```

### Get User Response

```js
200 Ok
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Vegan Sunshine",
    "description": "Vegan everything! Join us for a healthy breakfast..",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "lastModifiedDateTime": "2022-04-06T12:00:00",
    "savory": [
        "Oatmeal",
        "Avocado Toast",
        "Omelette",
        "Salad"
    ],
    "Sweet": [
        "Cookie"
    ]
}
```

## Update Breakfast

### Update Breakfast Request

```js
PUT /breakfasts/{{id}}
```

```json
{
    "name": "Vegan Sunshine",
    "description": "Vegan everything! Join us for a healthy breakfast..",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "savory": [
        "Oatmeal",
        "Avocado Toast",
        "Omelette",
        "Salad"
    ],
    "Sweet": [
        "Cookie"
    ]
}
```

### Update Breakfast Response

```js
204 No Content
```

or

```js
201 Created
```

```yml
Location: {{host}}/Breakfasts/{{id}}
```

## Delete Breakfast

### Delete Breakfast Request

```js
DELETE /breakfasts/{{id}}
```

### Delete Breakfast Response

```js
204 No Content
```