namespace MyStudioProject.Controllers {

    export class HomeController {
        private StudentsResource;
        public students;

        public getStudents() {
            this.students = this.StudentsResource.query();
        }

        constructor(private $resource: angular.resource.IResourceService) {
            this.StudentsResource = $resource('/api/students/:id');
            this.getStudents();
        }
    }

    export class OrganizerController {
        private AllStudentsResource;
        public studentsTwo;

        public getAllStudents() {
            this.studentsTwo = this.AllStudentsResource.query();
        }

        constructor(private $resource: angular.resource.IResourceService) {
            this.AllStudentsResource = $resource('/api/organizers/:id');
            this.getAllStudents();
        }
    }


    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }


    export class AddStudentController {
        private StudentResource;
        private RhythmsResource;
        private InstructorsResource;
        public student;
        public rhythms;
        public instructors;


        public getRhythms() {
            this.rhythms = this.RhythmsResource.query();
        }

        public getInstructors() {
            this.instructors = this.InstructorsResource.query();
        }

        public addStudent() {
            this.StudentResource.save(this.student).$promise.then(() => { this.$state.go('organizers') })
        }

        constructor(private $resource: angular.resource.IResourceService, private $state: ng.ui.IStateService) {
            this.StudentResource = $resource('/api/organizers/:id');
            this.RhythmsResource = $resource('/api/rhythms/:id');
            this.InstructorsResource = $resource('/api/instructors/:id');

            this.getRhythms();
            this.getInstructors();
        }
    }

    export class EditStudentController {
        private StudentResource;
        public student;         
            
                

        editStudent() {
            this.StudentResource.save(this.student).$promise.then(
                () => this.$state.go('organizers')
            );
        }

        constructor(private $resource: angular.resource.IResourceService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService) {
            this.StudentResource = $resource('/api/organizers/:id');                    
            this.student = this.StudentResource.get({ id: this.$stateParams['id'] })            
        }
    }
    export class DeleteStudentController {
        private StudentResource;
        public student;


        public deleteStudent(id) {
            this.StudentResource.delete(this.student).$promise.then(
                () => this.$state.go('organizers')
            );
        }

        constructor(private $resource: angular.resource.IResourceService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService) {
            this.StudentResource = $resource('/api/organizers/:id');
            this.student = this.StudentResource.get({ id: this.$stateParams['id'] })


        }
    }
}
