# API Documentation

## Base URL
`http://localhost:5000`

---

## Endpoints

### 1. Login

**POST** `/login`

#### Request Body
```json
{
    "email": "isacrodriguesdev@protonmail.com",
    "password": "test"
}
```

#### Response
- **200 OK**: Login successful, returns user token.
- **401 Unauthorized**: Invalid email or password.

---

### 2. Create User

**POST** `/user`

#### Request Body
```json
{
    "id": "c25c2ec5-f68d-4e00-8852-c0f55ab646e5",
    "name": "Isac Rodrigues",
    "email": "isacrodriguesdev@protonmail.com",
    "password": "test",
    "birthDate": "14-08-1999",
    "cpf": "00000000000",
    "createdAt": "2025-01-22T21:54:22.7875659Z",
    "updatedAt": "2025-01-22T21:54:22.787566Z"
}
```

#### Response
- **201 Created**: User created successfully.
  ```json
  {
      "name": "Isac Rodrigues",
      "email": "isacrodriguesdev@protonmail.com",
      "birthDate": "14-08-1999",
      "cpf": "00000000000",
      "id": "c25c2ec5-f68d-4e00-8852-c0f55ab646e5",
      "createdAt": "2025-01-22T21:54:22.7875659Z",
      "updatedAt": "2025-01-22T21:54:22.787566Z"
  }
  ```
- **400 Bad Request**: Validation errors or missing fields.

---

### 3. Create Wallet

**POST** `/wallet`

#### Request Body
```json
{
    "userId": "c25c2ec5-f68d-4e00-8852-c0f55ab646e5",
    "bank": "nubank"
}
```

#### Response
- **201 Created**: Wallet created successfully.
  ```json
  {
      "userId": "c25c2ec5-f68d-4e00-8852-c0f55ab646e5",
      "balance": 0,
      "bank": "nubank",
      "id": "e3a795fa-21de-45c5-bcc0-e5fc1a69ed3d",
      "createdAt": "2025-01-22T21:57:44.6888305Z",
      "updatedAt": "2025-01-22T21:57:44.6888305Z"
  }
  ```
- **400 Bad Request**: Validation errors or missing fields.

---

### 4. Get Wallet Details

**GET** `/wallet/{walletId}`

#### Path Parameters
- `walletId` (string): The unique identifier of the wallet.

#### Response
- **200 OK**: Returns wallet details.
  ```json
  [
    {
	"id": "60258b5c-2289-4bdf-8f4d-63d4ffc70dd0",
	"userId": "c25c2ec5-f68d-4e00-8852-c0f55ab646e5",
	"balance": 0,
	"bank": "nubank",
	"createdAt": "2025-01-22T21:52:49.309617Z",
	"updatedAt": "2025-01-22T21:52:49.309617Z"
    }
  ]
  ```
- **404 Not Found**: Wallet not found for the given `walletId`.

---

## Notes
1. All requests and responses use JSON format.
2. Authentication token (if implemented) should be included in the `Authorization` header for restricted endpoints.
3. Date formats should follow `DD-MM-YYYY`. Validation errors may occur for incorrect formats.

---
