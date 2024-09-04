# ZhilFond
 
Контроллер Balance
Адрес: https://localhost:7181/Balance
	Get-запрос с указанием query параметров accountId  и periodType возвращает таблицу по запрашиваемому accountId  и группирует по типу периода periodType (данные берутся из базы данных).
periodType может принимать следующие параметры: Year, Quarter, Month (без учета регистра). (Пример:  https://localhost:7181/Balance?accountId=808251&periodType=year)
Заголовок accept : text/xml – вернет результат в формате xml
Заголовок accept : text/json – вернет результат в формате json
Ответ возвращается в виде списка:
[
  {
    "period": "2021 год",
    "inBalance": 8860.87,
    "calculation": 12535.47,
    "paid": 16570.19,
    "outBalance": 4826.15
  },
…
]
Где period – наименование периода, inBalance – начальное сальдо периода, calculation – сумма начислений за период, paid – сумма выплат за период, outbalance – исходящее сальдо на конец периода.

Адрес: https://localhost:7181/Balance/Debt
Get-запрос с указанием query параметра accountId  возвращает текущую задолженность (данные берутся из базы данных). (Пример:  https://localhost:7181/Balance/Debt?accountId=808251)

Контроллер Accrual
Адрес: https://localhost:7181/Accrual
Get-запрос с указанием query параметра accountId возвращает все начисления данного аккаунта. (Пример:  https://localhost:7181/Accrual?accountId=808251)
Заголовок accept : text/xml – вернет результат в формате xml
Заголовок accept : text/json – вернет результат в формате json

Post-запрос позволяет добавить новое начисление в форме:
{
  "accountId": 0,
  "period": 0,
  "inBalance": 0,
  "calculation": 0
}

Адрес: https://localhost:7181/Accrual/UploadFile
Post-запрос принимает файл и позволяет добавить сразу несколько начислений.
Формат json файла:
{
“balance”: [
{
  "account_id": 0,
  "period": 0,
  "in_balance": 0,
  "calculation": 0
}
…
]
}

Контроллер Payment
Адрес: https://localhost:7181/Payment
Get-запрос с указанием query параметра accountId возвращает все выплаты данного аккаунта. (Пример:  https://localhost:7181/Payment?accountId=808251)
Заголовок accept : text/xml – вернет результат в формате xml
Заголовок accept : text/json – вернет результат в формате json
Post-запрос позволяет добавить новую выплату в форме:
{
  "accountId": 0,
  "date": "string",
  "sum": 0,
  "paymentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
}

Адрес: https://localhost:7181/Payment/UploadFile
Post-запрос принимает файл и позволяет добавить сразу несколько выплат.
Формат json файла:
[
{
  "account_id": 0,
  "date": "string",
  "sum": 0,
  "payment_guid": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
}
…
]
