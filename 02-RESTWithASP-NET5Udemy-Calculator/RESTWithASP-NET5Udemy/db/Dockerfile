FROM mysql:5.7.22
EXPOSE 3306
COPY ./RESTWithASP-NET5Udemy/db/migrations/ /home/database/
COPY ./RESTWithASP-NET5Udemy/db/dataset/ /home/database/
COPY ./RESTWithASP-NET5Udemy/ci/init_database.sh/ /docker-entrypoint-initdb.d/init_database.sh