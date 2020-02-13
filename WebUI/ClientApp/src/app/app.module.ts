import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule, HttpClient } from "@angular/common/http";
import { RouterModule, Routes } from "@angular/router";
import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { HomeComponent } from "./home/home.component";
import { EmployeeService, API_BASE_URL } from "./api-generated";
import { ProductenService } from "./api-generated";
import { KeukenComponent } from "./keuken/keuken.component";
import { KitchenOrdersService, BestellingenService } from "./api-generated";
import { KassaComponent } from "./kassa/kassa.component";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    KeukenComponent,
    KassaComponent
  ],

  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      { path: "Kassa", component: KassaComponent, pathMatch: "full" },
      { path: "keuken", component: KeukenComponent }
    ])
  ],
  providers: [
    EmployeeService,
    HttpClient,
    { provide: API_BASE_URL, useValue: "" },
    ProductenService,
    KitchenOrdersService,
    BestellingenService,
    KeukenComponent
  ],
  bootstrap: [AppComponent],
  exports: [RouterModule]
})
export class AppModule {}
