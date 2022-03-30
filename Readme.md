# Resumo
Kafka Broker - Controler 
ZooKeeper (Apache) - Gestão de recursos e ambientes distribuidos, gerencia um ou mais broker
Padrão Nome Topic - <organization>.<application-name>.<event-type>.<event>

# Executar ambiente
1 - Subir o ambiente -  docker-compose up -d
2 - Criar a tabelas
3 - Habilitar o CDC
4 - Registrar o Conector

# Connector
- Connectors - http://192.168.1.87:8083/connectors
- Plugins - http://192.168.1.87:8083/connector-plugins

- Configurando um conector SQL 
https://debezium.io/documentation/reference/stable/connectors/sqlserver.html

- Criar um router
https://debezium.io/documentation/reference/stable/transformations/outbox-event-router.html

# Dash Kafdrop
http://localhost:19000/