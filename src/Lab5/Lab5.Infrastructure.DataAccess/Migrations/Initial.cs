using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Lab5.Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
        create type user_role as enum
        (
            'admin' ,
            'customer'
        );
        
        create type operation_type as enum
        (
            'deposit' ,
            'withdrawal'
        );
        
        create type operation_state as enum
        (
            'successful' ,
            'failed'
        );
        
        create type account_state as enum
        (
            'open' ,
            'close'
        );
        
        create table users
        (
            user_id bigint primary key generated always as identity ,
            user_name text not null ,
            user_role user_role not null
        );
        
        create table admins_accounts
        (
            account_id bigint primary key generated always as identity ,
            user_id bigint not null references users(user_id) ,
            account_pin_code text not null ,
            
            primary key (account_id, user_id) ,
            check ((select user_role from users where user_id = admins_accounts.user_id) = 'admin')
        );
        
        create table customers_accounts
        (
            account_id bigint primary key generated always as identity ,
            user_id bigint not null references users(user_id) ,
            account_balance numeric(20, 2) not null ,
            account_state account_state not null ,
            account_open_date date not null ,
            account_close_date date ,
            account_pin_code text not null
            
            primary key (account_id, user_id) ,
            check (account_id >= 10000000 and account_id <= 99999999) ,
            check ((select user_role from users where user_id = customer_accounts.user_id) = 'customer')
        );
        
        create table customers_accounts_operations_history
        (
            account_id bigint not null references customers_accounts(account_id) ,
            operation_type operation_type not null ,
            operation_amount numeric(15, 2) not null ,
            operation_state operation_state not null ,
            operation_date date not null
        );
        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
        drop table users;
        drop table admins_accounts;
        drop table customers_accounts;
        drop table customers_accounts_operations_history;

        drop type user_role;
        drop type operation_type;
        drop type operation_state;
        drop type account_state;
        """;
}