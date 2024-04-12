<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FrmTipoIndicador.aspx.cs" Inherits="proyectoindicadores2.FrmTipoIndicador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <div class="container-xl">
            <div class="table-responsive">
                <div class="table-wrapper">
                    <div class="table-title">
                        <div class="row">
                            <div class="col-sm-6">
                                <h2 class="miEstilo">Gestión <b>Tipos de Indicador</b></h2>
                            </div>
                            <div class="col-sm-6">
                                <a href="#crudModal" class="btn btn-success" data-toggle="modal"><i class="material-icons">&#xE147;</i> <span>Gestión Tipos de Indicador</span></a>
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
                            <% for (int i = 0; i < arregloTiposIndicador.Length; i++) { %>
                            <tr>
                                <td>
                                    <span class="custom-checkbox">
                                        <input type="checkbox" id="checkbox1" name="options[]" value="1">
                                        <label for="checkbox1"></label>
                                    </span>
                                </td>
                                <td><% Response.Write(arregloTiposIndicador[i].Id); %></td>
                                <td><% Response.Write(arregloTiposIndicador[i].Nombre); %></td>
                                <td>
                                    <a href="#" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a>
                                </td>
                            </tr>
                            <% } %>
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
                        <h4 class="modal-title">Tipos de Indicador</h4>
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    </div>
                    <div class="modal-body">
                        <br>
                        <div class="container">
                            <br>
                            <!-- Nav tabs -->
                            <ul class="nav nav-tabs" role="tablist">
                                <li class="nav-item">
                                    <a class="nav-link active" data-toggle="tab" href="#idtipoindicador">Tipo Indicador</a>
                                </li>
                            </ul>

                            <!-- Tab panes -->
                            <div class="tab-content">
                                <div id="idtipoindicador" class="container tab-pane active"><br>
                                    <div class="form-group">
                                        <label>Id</label>
                                        <asp:TextBox ID="txtId" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>Nombre</label>
                                        <asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" class="btn btn-success" OnClick="BtnGuardar_Click" />
                                        <asp:Button ID="BtnConsultar" runat="server" Text="Consultar" class="btn btn-success" OnClick="BtnConsultar_Click" />
                                        <asp:Button ID="BtnModificar" runat="server" Text="Modificar" class="btn btn-warning" OnClick="BtnModificar_Click" />
                                        <asp:Button ID="BtnBorrar" runat="server" Text="Borrar" class="btn btn-warning" OnClick="BtnBorrar_Click" />
                                    </div>
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
