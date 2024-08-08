<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MediConnect.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Carousel Start -->
    <div class="container-fluid p-0 mb-5 wow fadeIn" data-wow-delay="0.1s">
        <div id="header-carousel" class="carousel slide carousel-fade" data-bs-ride="carousel">
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img class="w-100" src="assets/client/img/carousel-1.jpg" alt="Image">
                    <div class="carousel-caption">
                        <div class="container">
                            <div class="row justify-content-start">
                                <div class="col-lg-8">
                                    <p class="d-inline-block border border-white rounded text-primary fw-semi-bold py-1 px-3 animated slideInDown">
                                        Welcome to MediConnect
                               
                                    </p>
                                    <h1 class="display-1 mb-4 animated slideInDown">Streamlined supply for health
                                </h1>
                                    <a href="Register.aspx" class="btn btn-primary py-3 px-5 animated slideInDown">Explore More</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="carousel-item">
                    <img class="w-100" src="assets/client/img/carousel-2.jpg" alt="Image">
                    <div class="carousel-caption">
                        <div class="container">
                            <div class="row justify-content-start">
                                <div class="col-lg-7">
                                    <p class="d-inline-block border border-white rounded text-primary fw-semi-bold py-1 px-3 animated slideInDown">
                                        Welcome to MediConnect
                               
                                    </p>
                                    <h1 class="display-1 mb-4 animated slideInDown">Caring for better supply</h1>
                                    <a href="Register.aspx" class="btn btn-primary py-3 px-5 animated slideInDown">Explore More</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#header-carousel" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#header-carousel" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>
    </div>
    <!-- Carousel End -->
    
    <!-- Features Start -->
    <div class="container-xxl feature py-5">
        <div class="container">
            <div class="row g-5 align-items-center">
                <div class="col-lg-6 wow fadeInUp" data-wow-delay="0.1s">
                    <p class="d-inline-block border rounded text-primary fw-semi-bold py-1 px-3">Why Choosing Us!</p>
                    <h1 class="display-5 mb-4">Few Reasons Why People Choosing Us!</h1>
                    <p class="mb-4">
                        Tempor erat elitr rebum at clita. Diam dolor diam ipsum sit. Aliqu diam amet diam et
                    eos. Clita erat ipsum et lorem et sit, sed stet lorem sit clita duo justo magna dolore erat amet
               
                    </p>
                    <a class="btn btn-primary py-3 px-5" href="">Explore More</a>
                </div>
                <div class="col-lg-6">
                    <div class="row g-4 align-items-center">
                        <div class="col-md-6">
                            <div class="row g-4">
                                <div class="col-12 wow fadeIn" data-wow-delay="0.3s">
                                    <div class="feature-box border rounded p-4">
                                        <i class="fa fa-check fa-3x text-primary mb-3"></i>
                                        <h4 class="mb-3">Real-time Tracking</h4>
                                        <p class="mb-3">
                                            Showcasing a live tracking feature that allows users to monitor the movement of pharmaceuticals in real-time, ensuring transparency and security.
                                        </p>
                                        <a class="fw-semi-bold" href="">Read More <i class="fa fa-arrow-right ms-1"></i>
                                        </a>
                                    </div>
                                </div>
                                <div class="col-12 wow fadeIn" data-wow-delay="0.5s">
                                    <div class="feature-box border rounded p-4">
                                        <i class="fa fa-check fa-3x text-primary mb-3"></i>
                                        <h4 class="mb-3">Inventory Management</h4>
                                        <p class="mb-3">
                                            Highlighting an inventory management system that helps pharmaceutical companies optimize stock levels, reduce wastage, and ensure timely availability of products.
                                   
                                        </p>
                                        <a class="fw-semi-bold" href="">Read More <i class="fa fa-arrow-right ms-1"></i>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 wow fadeIn" data-wow-delay="0.7s">
                            <div class="feature-box border rounded p-4">
                                <i class="fa fa-check fa-3x text-primary mb-3"></i>
                                <h4 class="mb-3">Compliance and Regulation</h4>
                                <p class="mb-3">
                                    Featuring tools that help users stay compliant with pharmaceutical regulations, ensuring that all supply chain activities meet industry standards.
                           
                                </p>
                                <a class="fw-semi-bold" href="">Read More <i class="fa fa-arrow-right ms-1"></i></a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Features End -->
    
    <!-- Callback Start -->
    <div class="container-fluid callback my-5 pt-5">
        <div class="container pt-5">
            <div class="row justify-content-center">
                <div class="col-lg-7">
                    <div class="bg-white border rounded p-4 p-sm-5 wow fadeInUp" data-wow-delay="0.5s">
                        <div class="text-center mx-auto wow fadeInUp" data-wow-delay="0.1s" style="max-width: 600px;">
                            <p class="d-inline-block border rounded text-primary fw-semi-bold py-1 px-3">
                                Get In Touch
                       
                            </p>
                            <h1 class="display-5 mb-5">Request A Call-Back</h1>
                        </div>
                        <div class="row g-3">
                            <div class="col-sm-6">
                                <div class="form-floating">
                                    <asp:TextBox CssClass="form-control" ID="Name" runat="server" placeholder="Your Name"></asp:TextBox>
                                    <label for="Name">Your Name</label>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-floating">
                                    <asp:TextBox CssClass="form-control" ID="Email" runat="server" placeholder="Your Email"></asp:TextBox>
                                    <label for="Email">Your Email</label>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-floating">
                                    <asp:TextBox CssClass="form-control" ID="Mobile" runat="server" placeholder="Your Mobile"></asp:TextBox>
                                    <label for="Mobile">Your Mobile</label>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-floating">
                                    <asp:TextBox CssClass="form-control" ID="Subject" runat="server" placeholder="Subject"></asp:TextBox>
                                    <label for="Subject">Subject</label>
                                </div>
                            </div>
                            <div class="col-12">
                                <div class="form-floating">
                                    <asp:TextBox CssClass="form-control" ID="Message" runat="server" placeholder="Leave a message here" TextMode="MultiLine" style="height: 100px"></asp:TextBox>
                                    <label for="Message">Message</label>
                                </div>
                            </div>
                            <div class="col-12 text-center">
                                <asp:Button CssClass="btn btn-primary w-100 py-3" ID="SubmitButton" runat="server" Text="Submit Now" OnClick="SubmitButton_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
    <!-- Testimonial Start -->
    <div class="container-xxl py-5">
        <div class="container">
            <div class="text-center mx-auto wow fadeInUp" data-wow-delay="0.1s" style="max-width: 600px;">
                <p class="d-inline-block border rounded text-primary fw-semi-bold py-1 px-3">Testimonial</p>
                <h1 class="display-5 mb-5">What Our Clients Say!</h1>
            </div>
            <div class="owl-carousel testimonial-carousel wow fadeInUp" data-wow-delay="0.3s">
                <div class="testimonial-item">
                    <div class="testimonial-text border rounded p-4 pt-5 mb-5">
                        <div class="btn-square bg-white border rounded-circle">
                            <i class="fa fa-quote-right fa-2x text-primary"></i>
                        </div>
                        Dolores sed duo clita tempor justo dolor et stet lorem kasd labore dolore lorem ipsum. At lorem
                    lorem magna ut et, nonumy et labore et tempor diam tempor erat.
               
                    </div>
                    <img class="rounded-circle mb-3" src="assets/client/img/testimonial-1.jpg" alt="">
                    <h4>Client Name</h4>
                    <span>Profession</span>
                </div>
                <div class="testimonial-item">
                    <div class="testimonial-text border rounded p-4 pt-5 mb-5">
                        <div class="btn-square bg-white border rounded-circle">
                            <i class="fa fa-quote-right fa-2x text-primary"></i>
                        </div>
                        Dolores sed duo clita tempor justo dolor et stet lorem kasd labore dolore lorem ipsum. At lorem
                    lorem magna ut et, nonumy et labore et tempor diam tempor erat.
               
                    </div>
                    <img class="rounded-circle mb-3" src="assets/client/img/testimonial-2.jpg" alt="">
                    <h4>Client Name</h4>
                    <span>Profession</span>
                </div>
                <div class="testimonial-item">
                    <div class="testimonial-text border rounded p-4 pt-5 mb-5">
                        <div class="btn-square bg-white border rounded-circle">
                            <i class="fa fa-quote-right fa-2x text-primary"></i>
                        </div>
                        Dolores sed duo clita tempor justo dolor et stet lorem kasd labore dolore lorem ipsum. At lorem
                    lorem magna ut et, nonumy et labore et tempor diam tempor erat.
               
                    </div>
                    <img class="rounded-circle mb-3" src="assets/client/img/testimonial-3.jpg" alt="">
                    <h4>Client Name</h4>
                    <span>Profession</span>
                </div>
                <div class="testimonial-item">
                    <div class="testimonial-text border rounded p-4 pt-5 mb-5">
                        <div class="btn-square bg-white border rounded-circle">
                            <i class="fa fa-quote-right fa-2x text-primary"></i>
                        </div>
                        Dolores sed duo clita tempor justo dolor et stet lorem kasd labore dolore lorem ipsum. At lorem
                    lorem magna ut et, nonumy et labore et tempor diam tempor erat.
               
                    </div>
                    <img class="rounded-circle mb-3" src="assets/client/img/testimonial-4.jpg" alt="">
                    <h4>Client Name</h4>
                    <span>Profession</span>
                </div>
            </div>
        </div>
    </div>
    <!-- Testimonial End -->
</asp:Content>
