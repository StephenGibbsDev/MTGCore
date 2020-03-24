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
                  <label for="email">Email address</label>
                  <input type="email" class="form-control" id="email" placeholder="Enter email" />
                </div>
                <div class="form-group">
                  <label for="firstname">First Name</label>
                  <input
                    type="text"
                    class="form-control"
                    id="firstname"
                    placeholder="Enter firstname"
                  />
                </div>
                <div class="form-group">
                  <label for="surname">Surname</label>
                  <input type="text" class="form-control" id="surname" placeholder="Enter surname" />
                </div>
                <div class="form-group">
                  <label for="password">Password</label>
                  <input type="password" class="form-control" id="password" placeholder="Password" />
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>