<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Student.Master" AutoEventWireup="true" CodeBehind="Statistics.aspx.cs" Inherits="VirtualExam.Page.Statistics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <asp:Panel ID="Panel1" runat="server">
           <div class="calender">

                <div class="takvim">
                <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            </div>
            <div  class="takvim">
                 <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>
            </div>
           </div>



            <div class="btnList">

                 <asp:Button ID="btnList"  CssClass="btn" runat="server" Text="Listele" OnClick="btnList_Click" />
            </div>
    </asp:Panel>

    <asp:Panel ID="Panel2" runat="server" Visible="false">
      <div class="chartStatic">
        <asp:Chart ID="Chart1" runat="server" Palette="Chocolate" Width="350px">
        <Series>
            <asp:Series Name="Konu" Color="AppWorkspace" YValuesPerPoint="2"></asp:Series>
         
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"> 
                
                
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>

        <asp:Chart ID="Chart2" runat="server" Palette="Chocolate" Width="350px">
        <Series>
          
            <asp:Series Name="Doğru" Color="ForestGreen" YValuesPerPoint="2"></asp:Series>
            
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"> 
                
                
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>

        <asp:Chart ID="Chart3" runat="server" Palette="Chocolate" Width="350px">
        <Series>
           
            <asp:Series Name="Yanlış" Color="Red" YValuesPerPoint="2" YValueType="Double"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"> 
                
                
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
  </div>

        </asp:Panel>
</asp:Content>
