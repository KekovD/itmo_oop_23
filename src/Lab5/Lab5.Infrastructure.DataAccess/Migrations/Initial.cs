using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Lab5.Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
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
        
        create table admins_accounts
        (
            account_id bigint primary key not null unique ,
            account_pin_code text not null
        );
        
        create table customers_accounts
        (
            account_id bigint primary key not null unique ,
            account_balance numeric(20, 2) not null ,
            account_state account_state not null ,
            account_open_date date not null ,
            account_close_date date ,
            account_pin_code text not null
        );
        
        create table customers_accounts_operations_history
        (
            account_id bigint primary key not null ,
            operation_id bigint generated always as identity ,
            operation_amount numeric(20, 2) not null check(operation_amount > 0) ,
            operation_type operation_type not null ,
            operation_state operation_state not null ,
            operation_date date not null
        );
        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
        drop table admins_accounts;
        drop table customers_accounts;
        drop table customers_accounts_operations_history;

        drop type operation_type;
        drop type operation_state;
        drop type account_state;
        """;
}