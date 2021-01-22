import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({ templateUrl: 'home.component.html'})
export class HomeComponent implements OnInit {
    newSearchTerm: string;
    searchForm: FormGroup;
    

    constructor(
        private formBuilder: FormBuilder,
        private router: Router
    ) {
        this.searchForm = this.formBuilder.group({
            searchTerm: ['', Validators.required]
        });
    }

    ngOnInit() {
    }

    onSearch(){
        this.newSearchTerm = this.searchForm.controls.searchTerm.value;
    }

}