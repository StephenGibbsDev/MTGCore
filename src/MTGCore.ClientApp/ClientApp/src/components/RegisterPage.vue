<template>
  <div>
    <div class="jumbotron">
      <div class="container">
        <div class="row">
          <div class="col-sm-6 offset-sm-3">
            <div>
              <h2>Register</h2>
              <form>
                <div class="form-group">
                  <label for="Username">Username</label>
                  <input type="text" class="form-control" id="Username" placeholder="Enter Username" />
                </div>
                <div class="form-group">
                  <label for="FirstName">First Name</label>
                  <input
                    type="text"
                    class="form-control"
                    id="FirstName"
                    placeholder="Enter firstname"
                  />
                </div>
                <div class="form-group">
                  <label for="LastName">Surname</label>
                  <input type="text" class="form-control" id="LastName" placeholder="Enter LastName" />
                </div>
                <div class="form-group">
                  <label for="Password">Password</label>
                  <input type="password" class="form-control" id="Password" placeholder="Password" />
                </div>
                <div class="form-group">
                  <button class="btn btn-primary">Register</button>
                  <router-link to="/login" class="btn btn-link">Cancel</router-link>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>