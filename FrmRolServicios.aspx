<%@ Page Title="Gestión de Roles" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FrmRolServicios.aspx.cs" Inherits="proyectoindicadores2.FrmRolServicios" Async="true" %>
<%@ Import Namespace="proyectoindicadores2.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-xl">
        <div class="table-responsive">
            <div class="table-wrapper">
                <div class="table-title">
                    <div class="row">
                        <div class="col-sm-6">
                            <h2 class="miEstilo">Gestión <b>Roles</b></h2>
                        </div>
                        <div class="col-sm-6">
                            <a href="#crudModal" class="btn btn-success" data-toggle="modal"><i class="material-icons">&#xE147;</i> <span>Gestón de Roles</span></a>
                        </div>
                    </div>
                </div>
					<table class="table table-striped table-hover">
						<thead>
							<tr>
								<th>
									<span class="custom-checkbox">
										<input type="checkbox" id="selectAll">
										<label for="selectAll"></label>
									</span>
								</th>
								<th>Id</th>
								<th>Nombre</th>
								<th>Actions</th>
							</tr>
						</thead>
                        <tbody>
                            <%
                                var arregloRoles = Session["arregloRoles"] as List<Entidad>;
                                if (arregloRoles != null)
                                {
                                    foreach (var rol in arregloRoles)
                                    {
                            %>
                                        <tr>
                                            <td>
                                                <span class="custom-checkbox">
                                                    <input type="checkbox" id="checkbox<%= rol["id"] %>" name="options[]" value="<%= rol["id"] %>">
                                                    <label for="checkbox<%= rol["id"] %>"></label>
                                                </span>
                                            </td>
                                            <td><%= rol["id"] %></td>
                                            <td><%= rol["nombre"] %></td>
                                            <td>
                                                <a href="#crudModal" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a>
                                                <a href="#crudModal" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a>
                                            </td>
                                        </tr>
                            <%
                                    }
                                }
                            %>
                        </tbody>
					</table>

            </div>
        </div>
    </div>
<!-- CRUD Modal HTML para acciones sobre roles -->
<div id="crudModal" class="modal fade">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title">Gestión de Roles</h4>
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            </div>
            <div class="modal-body">
                    <div class="form-group">
                        <label>ID (solo para consultar, modificar, borrar)</label>
                        <asp:TextBox ID="txtId" runat="server" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <label>Nombre del Rol</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                    </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="BtnGuardar_Click" />
                <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-primary" OnClick="BtnConsultar_Click" />
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-warning" OnClick="BtnModificar_Click" />
                <asp:Button ID="btnBorrar" runat="server" Text="Borrar" CssClass="btn btn-danger" OnClick="BtnBorrar_Click" />
                <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
            </div>
        </div>
    </div>
</div>

</asp:Content>
