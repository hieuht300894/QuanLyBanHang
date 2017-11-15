SET IDENTITY_INSERT xAgency ON
INSERT INTO xAgency
([KeyID],[Code],[Name],[Address],[Phone],[Email],[Credentials],[HostAddress],[HostPort],[Logo],[Description],[IsEnable],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])
VALUES (1,'AGE0001',N'Agency 1',N'Ho Chi Minh City',N'0123456789','agency1@gmail.com',NULL,NULL,0,CONVERT(varbinary(max),NULL,1),N'',1,0,CONVERT(datetime,GETDATE(),121),NULL,CONVERT(datetime,NULL,121));
SET IDENTITY_INSERT xAgency OFF