SELECT TehdytTeotID, Tekopvm, DATEADD(MONTH, 6, Tekopvm) 
AS VoimassaOloPvm FROM dbo.SAKtehdytteot;