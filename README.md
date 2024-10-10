# ZhilFond

**Контроллер** **Balance**

Адрес: [https://localhost:7181/Balance](https://localhost:7181/Balance)

Get-запрос с указанием _query_ параметров _accountId_  и _periodType_ возвращает таблицу по запрашиваемому _accountId_  и группирует по типу периода _periodType_ (данные берутся из базы данных).

_periodType_ может принимать следующие параметры: Year, Quarter, Month (без учета регистра). (Пример:  [https://localhost:7181/Balance?accountId=808251&periodType=year](https://localhost:7181/Balance?accountId=808251&periodType=year))

Заголовок _accept :_ _text/xml_ – вернет результат в формате xml
Заголовок _accept :_ _text/json_ – вернет результат в формате json

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

Где _period_ – наименование периода, _inBalance_ – начальное сальдо периода, _calculation_ – сумма начислений за период, _paid_ – сумма выплат за период, _outbalance_ – исходящее сальдо на конец периода.

Адрес: [https://localhost:7181/Balance/Debt](https://localhost:7181/Balance/Debt)

Get-запрос с указанием _query_ параметра _accountId_  возвращает текущую задолженность (данные берутся из базы данных). (Пример:  [https://localhost:7181/Balance/Debt?accountId=808251](https://localhost:7181/Balance/Debt?accountId=808251))

---
**Контроллер** **Accrual**

Адрес: [https://localhost:7181/Accrual](https://localhost:7181/Accrual)

Get-запрос с указанием _query_ параметра _accountId_ возвращает все начисления данного аккаунта. (Пример:  [https://localhost:7181/Accrual?accountId=808251](https://localhost:7181/Accrual?accountId=808251))

Заголовок _accept :_ _text/xml_ – вернет результат в формате xml
Заголовок _accept :_ _text/json_ – вернет результат в формате json

Post-запрос позволяет добавить новое начисление в форме:

{
	"accountId": 0,
	"period": 0,
	"inBalance": 0,
	"calculation": 0
}

Адрес: [https://localhost:7181/Accrual/UploadFile](https://localhost:7181/Accrual/UploadFile)

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

---
**Контроллер Payment**

Адрес: [https://localhost:7181/Payment](https://localhost:7181/Payment)

Get-запрос с указанием _query_ параметра _accountId_ возвращает все выплаты данного аккаунта. (Пример:  [https://localhost:7181/Payment?accountId=808251](https://localhost:7181/Payment?accountId=808251))

Заголовок _accept :_ _text/xml_ – вернет результат в формате xml
Заголовок _accept :_ _text/json_ – вернет результат в формате json

Post-запрос позволяет добавить новую выплату в форме:

 {
	  "accountId": 0,
	  "date": "string",
	  "sum": 0,
	  "paymentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
}

Адрес: [https://localhost:7181/Payment/UploadFile](https://localhost:7181/Payment/UploadFile)

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
