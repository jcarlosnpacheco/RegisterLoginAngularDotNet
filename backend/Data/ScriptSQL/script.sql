-- Database: serviceOrder

-- DROP DATABASE "serviceOrder";

CREATE DATABASE "serviceOrder"
    WITH 
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'Portuguese_Brazil.1252'
    LC_CTYPE = 'Portuguese_Brazil.1252'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;

CREATE TABLE service (
	id serial PRIMARY KEY,
	description VARCHAR ( 150 ) NOT NULL,
	date_service TIMESTAMP NOT NULL,
	value_service decimal NOT NULL	
);