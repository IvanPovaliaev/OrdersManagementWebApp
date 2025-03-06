# OrdersManagementWebApp

![image](https://github.com/user-attachments/assets/5cc32dee-14d8-4977-aa3c-738f0e967fe7)

## Описание
Простое Web приложение для приемки заказа на доставку со следующим функционалом:
1. Форма создания нового заказа (все поля обязательны для заполнения):
- Город отправителя
- Адрес отправителя
- Город получателя
- Адрес получателя
- Вес груза
- Дата забора груза

2. Форма отображения списка заказов: все созданные заказы должны отображаться в отдельной форме. Помимо полей, введенных пользователем при создании заказа, отображается автоматически сгенерированный номер заказа.
3. Форма просмотра созданного заказа в режиме чтения. Открывается при клике на заказ в списке заказов.<br/>
<b>Примечание: форма выполнена в виде модального окна</b>

## Технологии
1. ASP.NET 9
2. PostgreSQL
3. Entity Framework Core
4. ASP.NET MVC
5. Automapper
7. MediatR
8. CQRS
10. CleanArchitecture
11. UnitOfWork
12. Serilog - логирование данных в файл и консоль
13. Docker

## Установка и настройка
Приложение доступно для запуска в 2х вариантах
### Вариант 1. Локальный запуск
0. Для локального запуска необходимо иметь установленную СУБД `PostgreSQL`.
1. Задать данные для подключения к базе данных в файле `.env`.
Дальнейших настроек не требует. Запускается через IDE.

### Вариант 2. Docker
#### 2.1. Запуск с генерацией образа
В решении имеется docker-compose файл для запуска приложения. Достаточно просто запустить его встроенными средставами IDE.
При желании можно настроить в файле:
1. Переменный окружения для БД и внешний том хранения данных
2. Строку подключения к БД у основного приложения

<b>Примечание:</b><br/>
На различных устройствах запуск через IDE может неверно считывать переменные окружения у основного приложения.<br/>
Для решения данной проблемы рекомендуется использовать команду `docker-compose up -d --build` 

#### 2.2. Запуск без генерации
Для сборки всего приложения, используйте приведённый compose файл.
<details><summary>docker-compose.yml</summary>

```
services:
  postgre:
    container_name: orders_management_db
    image: postgres:latest
    environment: 
      POSTGRES_USER: postgres
      POSTGRES_PASSWORD: Qwerty123!
      POSTGRES_DB: OrderManagement.Db
    ports:
      - 5432:5432
    networks:
      - orders-management-network
    volumes:
      - postgres_data:/var/lib/postgresql/data

  orders_management_webapp:
    image: ivanpovaliaev/orders_management_webapp:latest
    environment:
      DB_CONNECTION_STRING: "Host=postgre;Port=5432;Database=OrderManagement.Db;Username=postgres;Password=Qwerty123!;"
    depends_on:
      - postgre
    restart: unless-stopped
    ports:
      - 8080:8080
      - 8081:8081
    networks:
      - orders-management-network

networks:
    orders-management-network:

volumes:
    postgres_data:
```
</details>
