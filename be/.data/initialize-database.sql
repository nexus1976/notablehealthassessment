CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

DO $$
BEGIN
	IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = 'InitialMigration') THEN
        CREATE TABLE "Doctors" (
            id uuid NOT NULL,
            fulltitle character varying(100) NOT NULL,
            firstname character varying(100) NOT NULL,
            lastname character varying(100) NOT NULL,
            email character varying(256) NULL,
            officephone character varying(10) NULL,
            isdeactivated boolean NOT NULL DEFAULT FALSE,
            CONSTRAINT "PK_Doctors" PRIMARY KEY (id)
        );
	END IF;
END $$;

DO $$
BEGIN
	IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = 'InitialMigration') THEN
        CREATE TABLE "Patients" (
            id uuid NOT NULL,
            firstname character varying(100) NOT NULL,
            lastname character varying(100) NOT NULL,
            email character varying(256) NULL,
            isdeactivated boolean NOT NULL DEFAULT FALSE,
            CONSTRAINT "PK_Patients" PRIMARY KEY (id)
        );
	END IF;
END $$;

DO $$
BEGIN
	IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = 'InitialMigration') THEN
        CREATE TABLE "DoctorPatientSchedules" (
            id uuid NOT NULL,
            doctor_id uuid NOT NULL,
            patient_id uuid NOT NULL,
            patienttype int2 NOT NULL,
            appointmentdatetime timestamp without time zone NOT NULL,
            CONSTRAINT "PK_DoctorPatientSchedules" PRIMARY KEY (id)
        );
	END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = 'InitialMigration') THEN
        INSERT INTO "Doctors" ("id", "fulltitle", "firstname", "lastname", "email", "officephone", "isdeactivated")
        VALUES ('ee68f702-0866-4c00-ab8e-6dace37b552e', 'Dr. Julius Hibbert', 'Julius', 'Hibbert', 'jhibbert@notablehealth.com', '4055991234', false);     
    END IF;
END $$;
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = 'InitialMigration') THEN
        INSERT INTO "Doctors" ("id", "fulltitle", "firstname", "lastname", "email", "officephone", "isdeactivated")
        VALUES ('dfcd48e5-3c3b-413f-aa4d-264eab12d439', 'Dr. Algernop Krieger', 'Algernop', 'Krieger', 'krieger@notablehealth.com', '4055991234', false);
    END IF;
END $$;  
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = 'InitialMigration') THEN        
        INSERT INTO "Doctors" ("id", "fulltitle", "firstname", "lastname", "email", "officephone", "isdeactivated")
        VALUES ('e8cdbf75-7242-41b5-ae0a-86f77a0f438f', 'Dr. Nick Riviera', 'Nick', 'Riviera', 'nriviera@notablehealth.com', '4055991234', false); 
    END IF;
END $$;  
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = 'InitialMigration') THEN        
        INSERT INTO "Patients" ("id", "firstname", "lastname", "email", "isdeactivated") 
        VALUES ('88972c0a-3ad9-4835-abfb-5f9db02a2d96', 'Sterling', 'Archer', 'sarcher@isis.tv', false);
    END IF;
END $$;  
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = 'InitialMigration') THEN        
        INSERT INTO "Patients" ("id", "firstname", "lastname", "email", "isdeactivated") 
        VALUES ('a27c58dd-ddad-4160-9622-4ebe4149a58e', 'Cyril', 'Figis', 'cfigis@isis.tv', false);
    END IF;
END $$;  
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = 'InitialMigration') THEN        
        INSERT INTO "Patients" ("id", "firstname", "lastname", "email", "isdeactivated") 
        VALUES ('7affc9f5-f520-4906-bac2-41f8d43b53c8', 'Ray', 'Gilette', 'rgilette@isis.tv', false);
    END IF;
END $$;  
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = 'InitialMigration') THEN        
        INSERT INTO "Patients" ("id", "firstname", "lastname", "email", "isdeactivated") 
        VALUES ('86a35f14-d011-41b0-af17-7dd0cdc4fc9d', 'Lana', 'Kane', 'lkane@isis.tv', false);
    END IF;
END $$;  
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = 'InitialMigration') THEN        
        INSERT INTO "Patients" ("id", "firstname", "lastname", "email", "isdeactivated") 
        VALUES ('1b14564a-418c-46c0-a87a-cc1b109ed1ad', 'Pam', 'Poovey', 'ppoovey@isis.tv', false);
    END IF;
END $$;  
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = 'InitialMigration') THEN        
        INSERT INTO "Patients" ("id", "firstname", "lastname", "email", "isdeactivated") 
        VALUES ('4c9a2254-02f8-41b2-8339-d86e65d5c3a9', 'Daniel', 'Graham', 'nexus76@outlook.com', false);
    END IF;
END $$;          
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = 'InitialMigration') THEN
        INSERT INTO "DoctorPatientSchedules" ("id", "doctor_id", "patient_id", "patienttype", "appointmentdatetime")
        VALUES ('bcf3e546-4bac-4f2f-9af1-d67466a4e587', 'dfcd48e5-3c3b-413f-aa4d-264eab12d439', '88972c0a-3ad9-4835-abfb-5f9db02a2d96', 1, '2022-05-28 08:00:00');
    END IF;
END $$;  
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = 'InitialMigration') THEN
        INSERT INTO "DoctorPatientSchedules" ("id", "doctor_id", "patient_id", "patienttype", "appointmentdatetime")
        VALUES ('083a8dcd-655f-48be-be36-e2f8c69021ab', 'dfcd48e5-3c3b-413f-aa4d-264eab12d439', 'a27c58dd-ddad-4160-9622-4ebe4149a58e', 2, '2022-05-28 08:30:00');
    END IF;
END $$;  
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = 'InitialMigration') THEN        
        INSERT INTO "DoctorPatientSchedules" ("id", "doctor_id", "patient_id", "patienttype", "appointmentdatetime")
        VALUES ('a3749ad1-7a98-4c70-bacf-85cdac09266f', 'dfcd48e5-3c3b-413f-aa4d-264eab12d439', '7affc9f5-f520-4906-bac2-41f8d43b53c8', 2, '2022-05-28 09:00:00');
    END IF;
END $$;  
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = 'InitialMigration') THEN        
        INSERT INTO "DoctorPatientSchedules" ("id", "doctor_id", "patient_id", "patienttype", "appointmentdatetime")
        VALUES ('f0e8379f-69b4-4ed6-b87e-cff44da16cc9', 'dfcd48e5-3c3b-413f-aa4d-264eab12d439', '86a35f14-d011-41b0-af17-7dd0cdc4fc9d', 1, '2022-05-28 09:30:00');
    END IF;
END $$;  
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = 'InitialMigration') THEN        
        INSERT INTO "DoctorPatientSchedules" ("id", "doctor_id", "patient_id", "patienttype", "appointmentdatetime")
        VALUES ('5d1b81ae-b133-46b6-95b9-0906a39b3ad9', 'dfcd48e5-3c3b-413f-aa4d-264eab12d439', '1b14564a-418c-46c0-a87a-cc1b109ed1ad', 1, '2022-05-28 10:00:00');
    END IF;
END $$;  
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = 'InitialMigration') THEN        
        INSERT INTO "DoctorPatientSchedules" ("id", "doctor_id", "patient_id", "patienttype", "appointmentdatetime")
        VALUES ('a9757bbc-17d3-4716-85ed-c3fdb3b6ae48', 'ee68f702-0866-4c00-ab8e-6dace37b552e', '4c9a2254-02f8-41b2-8339-d86e65d5c3a9', 1, '2022-05-28 10:00:00');   
    END IF;
END $$;  

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = 'InitialMigration') THEN
        INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
        VALUES ('InitialMigration', '1.0.0');
    END IF;
END $$;
COMMIT;
