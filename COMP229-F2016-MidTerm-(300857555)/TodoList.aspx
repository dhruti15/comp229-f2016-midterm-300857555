

<%@ Page Title="Todo List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoList.aspx.cs" Inherits="COMP229_F2016_MidTerm__300857555_.TodoList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-offset-2 col-md-8">

                <h1>Todo List</h1>
                <a href="TodoDetails.aspx" class="btn btn-success btn-sm">
                    <i class="fa fa-plus"></i> Add Todo
                </a>
               
              <asp:GridView ID="TodoListGridView" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-bordered table-striped table-hover" DataKeyNames="TodoID"
                    OnRowDeleting="TodoListGridView_RowDeleting" >
                    <Columns>
                       
                        <asp:BoundField DataField="TodoID" HeaderText="Todo ID" Visible="true" />
                        <asp:BoundField DataField="TodoDescription" HeaderText="Todo" Visible="true" />
                        <asp:BoundField DataField="TodoNotes" HeaderText="Notes" Visible="true" />
                        
                        
                        <asp:TemplateField HeaderText="Completed">
                            <EditItemTemplate>
                                <asp:CheckBox ID="CheckBox1" Visible="true" runat="server" /> 
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" Visible="true" runat="server" /> 
                            </ItemTemplate>
                            </asp:TemplateField>
                         <asp:HyperLinkField HeaderText="Edit" Text="<i class='fa fa-pencil-square-o fa-lg'></i> Edit"
                            NavigateUrl="~/TodoDetails.aspx.cs" ControlStyle-CssClass="btn btn-primary btn-sm"
                            runat="server" DataNavigateUrlFields="TodoID"
                            DataNavigateUrlFormatString="TodoDetails.aspx?TodoID={0}" />

                        <asp:CommandField HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'></i> Delete"
                            ShowDeleteButton="true" ButtonType="Link" ControlStyle-CssClass="btn btn-danger btn-sm" />
                    </Columns>
                </asp:GridView>
                </div>
            </div>
        </div> 
</asp:Content>
