use Teste

insert Outbox values (
'19a915b7-65a5-4edc-9ada-a8b255bd3129',
'participant',
'1',
'Inclusao',
'{
  "name": "Diego Armando",
  "birthDate": "1986-07-13",
  "totalIncome": 5000,
  "totalExpenses": 2500,
  "maritalStatus": "married",
  "professionalStatus": "worker"
}',
GETDATE())


insert Outbox values (
'19a915b7-65a5-4edc-9ada-a8b255bd6113',
'simulation',
'1',
'Inclusao',
'{"amount": 30000,"term": 1,"intermediaryId": "string","associateAccount": false,"collateral": {"marketValue": 0,"appraisalValue": 0,"location": "1000-001","registrationValue": 0}}',
GETDATE())

select * from Outbox
delete from Outbox


