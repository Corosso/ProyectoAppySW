<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FrmFuenteServicios.aspx.cs" Inherits="proyectoindicadores2.FrmFuenteServicios" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
		<div>
			<div class="container-xl">
			<div class="table-responsive">
				<div class="table-wrapper">
					<div class="table-title">
						<div class="row">
							<div class="col-sm-6">
								<h2 class="miEstilo">Gestión <b>Usuarios</b></h2>
							</div>
							<div class="col-sm-6">
								<a href="#crudModal" class="btn btn-success" data-toggle="modal"><i class="material-icons">&#xE147;</i> <span>Gestión Usuarios</span></a>						
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
								if (arregloEntidades != null)
								{
									foreach (var usuario in arregloEntidades)
									{
							%>
							<tr>
								<td>
									<span class="custom-checkbox">
										<input type="checkbox" id="checkbox<%= usuario["email"] %>" name="options[]" value="<%= usuario["email"] %>">
										<label for="checkbox<%= usuario["email"] %>"></label>
									</span>
								</td>
								<td><%= usuario["id"] %></td>
								<td><%= usuario["nombre"] %></td>
								<td>
									<a href="#" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a>
								</td>
							</tr>
							<%
									}
								}
							%>
						</tbody>
					</table>
					<div class="clearfix">
						<div class="hint-text">Showing <b>5</b> out of <b>25</b> entries</div>
						<ul class="pagination">
							<li class="page-item disabled"><a href="#">Previous</a></li>
							<li class="page-item"><a href="#" class="page-link">1</a></li>
							<li class="page-item"><a href="#" class="page-link">2</a></li>
							<li class="page-item active"><a href="#" class="page-link">3</a></li>
							<li class="page-item"><a href="#" class="page-link">4</a></li>
							<li class="page-item"><a href="#" class="page-link">5</a></li>
							<li class="page-item"><a href="#" class="page-link">Next</a></li>
						</ul>
					</div>
				</div>
			</div>        
		</div>
			<!-- Crud Modal HTML -->
		<div id="crudModal" class="modal fade">
			<div class="modal-dialog">
				<div class="modal-content">
						<div class="modal-header">						
							<h4 class="modal-title">Fuentes</h4>
							<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
						</div>
						<div class="modal-body">
							<br>
							<div class="container">
								<br>
								<!-- Nav tabs -->
								<ul class="nav nav-tabs" role="tablist">
									<li class="nav-item">
										<a class="nav-link active" data-toggle="tab" href="#idusuario">Fuente</a>
									</li>
									<li class="nav-item">
										<a class="nav-link" data-toggle="tab" href="#idrolesporusuario">Fuente por Indicador</a>
									</li>
								</ul>

								<!-- Tab panes -->
								<div class="tab-content">
									<div id="idusuario" class="container tab-pane active"><br>
										<div class="form-group">
											<label>Id</label>
											<asp:TextBox ID="txtEmail" runat="server" class="form-control"></asp:TextBox>
										</div>
										<div class="form-group">
											<label>Nombre</label>
											<asp:TextBox ID="txtContrasena" runat="server" class="form-control"></asp:TextBox>
										</div>
										<div class="form-group">
											<asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-success" OnClick="btnGuardar_Click"  />
											<asp:Button ID="btnConsultar" runat="server" Text="Consultar" class="btn btn-success" OnClick="btnConsultar_Click"  />
											<asp:Button ID="btnModificar" runat="server" Text="Modificar" class="btn btn-warning" OnClick="btnModificar_Click" />
											<asp:Button ID="btnBorrar" runat="server" Text="Borrar" class="btn btn-warning" OnClick="btnBorrar_Click"  />
										</div>
									</div>
									<div id="idrolesporusuario" class="container tab-pane fade"><br>
										<asp:UpdatePanel ID="UpdatePanel1" runat="server">
											<ContentTemplate>
														<div class="form-group">
															<label for="comboRoles">Fuentes</label>
															<asp:DropDownList ID="comboRoles" runat="server" class="form-control"></asp:DropDownList>
														</div>
														<div class="form-group">
															<label for="listRolesUsuario">Fuentes específicas de Indicadores</label>
															<asp:ListBox ID="listRolesUsuario" runat="server" class="form-control"></asp:ListBox>
														</div>
														<div class="form-group">
															<asp:Button ID="btnAgregar" runat="server" Text="Agregar Rol" class="btn btn-success" OnClick="btnAgregar_Click"  />
															<asp:Button ID="btnRemover" runat="server" Text="Remover Rol" class="btn btn-success" OnClick="btnRemover_Click"  />
														</div>
											</ContentTemplate>
										</asp:UpdatePanel>

									</div>
								</div>
							</div>
						</div>
						<div class="modal-footer">
							<input type="button" class="btn btn-default" data-dismiss="modal" value="Cancel">
						</div>
				</div>
			</div>
		</div>
       </div>
</asp:Content>
