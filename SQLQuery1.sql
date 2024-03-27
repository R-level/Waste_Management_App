CREATE TABLE sales(
id INT NOT NULL PRIMARY KEY IDENTITY,
company_name VARCHAR (100) NOT NULL,
company_contact VARCHAR (20),
glass_bottle_weight FLOAT,
glass_bottle_price FLOAT,
metal_weight FLOAT,
metal_price FLOAT,
cardboard_weight FLOAT,
cardboard_price FLOAT,
aluminium_can_weight FLOAT,
aluminium_can_price FLOAT,
paper_weight FLOAT,
paper_price FLOAT,
date  DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);
