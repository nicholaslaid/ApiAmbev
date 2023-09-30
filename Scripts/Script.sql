SELECT * FROM logs;
DROP TABLE IF EXISTS logs;
CREATE TABLE IF NOT EXISTS logs(
	id BIGSERIAL PRIMARY KEY,
	creation_date TIMESTAMP,
	type VARCHAR(10),
	message TEXT
);
SELECT * FROM produtos;
DROP TABLE IF EXISTS produtos;
CREATE TABLE IF NOT EXISTS produtos(
id serial PRIMARY KEY,
nome VARCHAR(50),
marca VARCHAR(50),
volume real,
tipo VARCHAR(30),
data time,
frasco VARCHAR(30)
);
