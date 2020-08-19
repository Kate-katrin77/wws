
select 
c.id, 
s.id,
s.stateCode 
from Customer c
inner join CustomerAddress ca on c.id=ca.CustomerId 
inner join Address a on ca.addressid = a.id
inner join State s on a.stateId=s.id
where c.id = 17413
group by c.id,s.id,s.stateCode
