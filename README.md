# QuanLyTinDung

Phần mềm quản lý tín dụng được xây dựng bằng C# WinForms và .NET 8.

## Công nghệ sử dụng

- C#
- .NET 8
- Windows Forms
- SQL Server
- Microsoft.Data.SqlClient

## Kiến trúc

Project được tổ chức theo mô hình:

- DTO: Data Transfer Object
- DAL: Data Access Layer
- BUS: Business Logic Layer
- Forms: Giao diện người dùng
- Common: Các thành phần dùng chung
- Security: Phân quyền và quản lý session
- Database: Script tạo cơ sở dữ liệu

## Cấu trúc project

```text
BUS/
Common/
Config/
DAL/
Database/
DTO/
Forms/
Reports/
Security/