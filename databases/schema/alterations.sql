USE recipeapi;

ALTER TABLE shoplist
    ADD start_date TIMESTAMP NOT NULL,
    ADD end_date TIMESTAMP NOT NULL;

UPDATE shoplist
	SET start_date = "2021-12-06 00:00:00", end_date = "2021-12-12 23:59:00"
    WHERE shoplist_id = "6000"