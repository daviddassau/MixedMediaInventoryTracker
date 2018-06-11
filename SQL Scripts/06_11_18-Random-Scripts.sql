SELECT m.Title,
FROM Media m
JOIN LentMedia l on l.Id = m.Id

SELECT l.Id, l.LendeeName, l.DateLent, l.Notes, m.Title, c.MediaCondition
FROM LentMedia l
JOIN Media m on m.Id = l.MediaId
JOIN MediaCondition c on c.Id = m.MediaConditionId

SELECT s.Id, s.Buyer, s.Amount, s.SoldDate, s.Notes, m.Title, c.MediaCondition
FROM SoldMedia s
JOIN Media m on m.Id = s.MediaId
JOIN MediaCondition c on c.Id = m.MediaConditionId

SELECT m.Id, m.Title, m.DatePurchased, m.DateAdded, m.IsLentOut, m.IsSold, m.Notes, c.MediaCondition, t.MediaType
FROM Media m
JOIN MediaCondition c on c.Id = m.MediaConditionId
JOIN MediaType t on t.Id = m.MediaTypeId
WHERE m.Id = 9


select * from Media

SELECT * FROM LentMedia

SELECT l.Id, l.LendeeName, l.DateLent, l.Notes, m.Title, c.MediaCondition
FROM LentMedia l
JOIN Media m on m.Id = l.MediaId
JOIN MediaCondition c on c.Id = m.MediaConditionId
WHERE L.Id = 2


SELECT s.Id, s.Buyer, s.Amount, s.SoldDate, s.Notes, m.Title, c.MediaCondition
FROM SoldMedia s
JOIN Media m on m.Id = s.MediaId
JOIN MediaCondition c on c.Id = m.MediaConditionId







INSERT INTO LentMedia VALUES (29,'Travis',1,'2018-06-05','Let Travis borrow this')
UPDATE Media SET IsLentOut = 1 WHERE Id = 29 

select * from LentMedia

SELECT m.Id, m.Title, c.MediaCondition
FROM Media m
JOIN MediaCondition c on c.Id = m.MediaConditionId
WHERE m.IsLentOut = 0



SELECT m.Id, m.Title, c.MediaCondition, m.IsSold
FROM Media m
JOIN MediaCondition c on c.Id = m.MediaConditionId
WHERE m.IsSold = 0

select * from SoldMedia
select * from Media

SELECT * FROM MediaType WHERE Id = 1