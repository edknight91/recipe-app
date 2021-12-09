CREATE DATABASE recipeapi;
USE recipeapi;

CREATE TABLE site_user
(
    site_user_id    INT NOT NULL AUTO_INCREMENT,
    username        VARCHAR(50) NOT NULL,

    PRIMARY KEY     (site_user_id)

) AUTO_INCREMENT=1000;

CREATE TABLE ingredient
(
    ingredient_id   INT NOT NULL AUTO_INCREMENT,
    title           VARCHAR(50) NOT NULL,
    wet             TINYINT(1) NOT NULL,
    algn_celery     TINYINT(1) NOT NULL,
    algn_gluten     TINYINT(1) NOT NULL,
    algn_crust      TINYINT(1) NOT NULL,
    algn_eggs       TINYINT(1) NOT NULL,
    algn_fish       TINYINT(1) NOT NULL,
    algn_lupin      TINYINT(1) NOT NULL,
    algn_milk       TINYINT(1) NOT NULL,
    algn_mollusc    TINYINT(1) NOT NULL,
    algn_mustard    TINYINT(1) NOT NULL,
    algn_peanut     TINYINT(1) NOT NULL,
    algn_sesame     TINYINT(1) NOT NULL,
    algn_soya       TINYINT(1) NOT NULL,
    algn_sulphite   TINYINT(1) NOT NULL,
    algn_treenut    TINYINT(1) NOT NULL,
    vegetarian      TINYINT(1) NOT NULL,
    vegan           TINYINT(1) NOT NULL,

    PRIMARY KEY     (ingredient_id)
) AUTO_INCREMENT=2000;

CREATE TABLE recipe
(
    recipe_id       INT NOT NULL AUTO_INCREMENT,
    title           VARCHAR(50) NOT NULL,
    method          VARCHAR(3000) NOT NULL,

    PRIMARY KEY     (recipe_id)
) AUTO_INCREMENT=3000;

CREATE TABLE recipe_ingredient
(
    recipe_ingredient_id    INT NOT NULL AUTO_INCREMENT,
    recipe_id               INT NOT NULL,
    ingredient_id           INT NOT NULL,
    quantity                INT NOT NULL,

    PRIMARY KEY     (recipe_ingredient_id),
    FOREIGN KEY     (recipe_id) REFERENCES recipe(recipe_id),
    FOREIGN KEY     (ingredient_id) REFERENCES ingredient(ingredient_id)
) AUTO_INCREMENT=4000;

CREATE TABLE meal
(
    meal_id         INT NOT NULL AUTO_INCREMENT,
    date_placed     TIMESTAMP NOT NULL,
    recipe_id       INT NOT NULL, 
    site_user_id    INT NOT NULL,

    PRIMARY KEY     (meal_id),
    FOREIGN KEY     (recipe_id) REFERENCES recipe(recipe_id),
    FOREIGN KEY     (site_user_id) REFERENCES site_user(site_user_id)
) AUTO_INCREMENT=5000;

CREATE TABLE shoplist
(
    shoplist_id         INT NOT NULL AUTO_INCREMENT,
    site_user_id        INT NOT NULL,

    PRIMARY KEY     (shoplist_id),
    FOREIGN KEY     (site_user_id) REFERENCES site_user(site_user_id)
) AUTO_INCREMENT=6000;

CREATE TABLE shoplist_meal
(
    shoplist_meal_id  INT NOT NULL AUTO_INCREMENT,
    shoplist_id       INT NOT NULL,
    meal_id           INT NOT NULL,

    PRIMARY KEY     (shoplist_meal_id),
    FOREIGN KEY     (shoplist_id) REFERENCES shoplist(shoplist_id),
    FOREIGN KEY     (meal_id) REFERENCES meal(meal_id)

) AUTO_INCREMENT=7000;